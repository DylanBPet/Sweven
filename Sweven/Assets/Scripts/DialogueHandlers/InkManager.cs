using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System.Collections;

public class InkManager : MonoBehaviour
{
    private Story currentStory;

    public GameObject textUI;
    public TextMeshProUGUI dialogueText;

    public GameObject[] choices;
    public TextMeshProUGUI[] choicesText;

    public bool finishedFirstDialogue = false;

    public int choiceNumber;

    public bool dialogueIsPlaying { get; private set; }


    /////////////For the names and icons///////////
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private const string HIDE_TAG = "hide";

    public TextMeshProUGUI displayNameText;

    public Animator portraitAnimator;

    private Animator layoutAnimator;

    ///for animating letters///
    private float typingSpeed = 0.03f;

    private Coroutine displayLineCoroutine;

    private bool canContinueToNextLine = false;

    public GameObject continueIcon;

    public LevelSwitchingHandler levelSwitchingHandlerScript;
    public FireLevelLogic fireLevelLogicScript;
    public FuneralLevelManager funeralLevelManager;
    public PoliceStationDayManager policeStationDayManager;
    public AnimalLevelPoliceStation AnimalLevelPoliceStation;
    public AnimalNightLevel animalNightLevel;
    public PlayerWalkingScript playerWalkingScript;
    public HumanLevelManagerScript humanLevelManagerScript;
    public FinalLevelManagerScript finalLevelManagerScript;

    void Start()
    {
        dialogueIsPlaying = false;
        finishedFirstDialogue = false;
        textUI.SetActive(false);

        //get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        layoutAnimator = textUI.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        if(canContinueToNextLine 
            && currentStory.currentChoices.Count == 0
            && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ContinueStory(); 
        }
    }

    public void StartDialogue()
    {
        dialogueIsPlaying = false;
        textUI.SetActive(false);

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        textUI.SetActive(true);
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;

        //reset portraits, layout, and speaker

       displayNameText.text = "Marcus";
       portraitAnimator.Play("marcus");
       layoutAnimator.Play("left");

       //levelSwitchingHandlerScript.RemoveObject(" ");

        ContinueStory();
    }

    private void ExitDialogueMode()
    {

        dialogueIsPlaying = false;
        textUI.SetActive(false);
        dialogueText.text = "";

        finishedFirstDialogue = true;
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {

            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }

           displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
                
            
            //handle tags
            HandleTags(currentStory.currentTags);
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";

        continueIcon.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;

        foreach(char letter in line.ToCharArray())
        {
            /* 
               idk why this not working
            if(Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                dialogueText.text = line;
                break;
            } 
            */

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        continueIcon.SetActive(true);

        //display choices, if any, for this dialogue line
        DisplayChoices();

        canContinueToNextLine = true;
    }

    public void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        //loop through each tag and handle it accordingly
        foreach (string tag in currentTags)
        {
            //parse the tag
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("tag could not be appropatly parsed: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            //handle the tag
            switch(tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    layoutAnimator.Play(tagValue);
                    break;
                case HIDE_TAG:
                    RemoveObject(tagValue);
                    break;
                default:
                    Debug.LogWarning("tag came in but is jnot currently being handled " + tag);
                    break;
            }
        }
    }

    /// here

    public void RemoveObject(string objectToRemove)
    {
        //remove the door in marcus room
        if (objectToRemove == "roomDoor")
        {
            levelSwitchingHandlerScript.RoomDoor();
        }
        //switch level to dream fire
        else if (objectToRemove == "goToSleep")
        {
            Debug.Log("goToSleep");
            levelSwitchingHandlerScript.GoToSleep();
        }
        else if (objectToRemove == "endDemo")
        {
            levelSwitchingHandlerScript.EndDemo();
        }
        else if (objectToRemove == "openEmergDoor")
        {
            fireLevelLogicScript.EmergDoorOpen();
        }
        else if (objectToRemove == "windowBreak")
        {
            fireLevelLogicScript.WindowBreak();
        }
        else if (objectToRemove == "rockPickedUp")
        {
            fireLevelLogicScript.RockPickedUp();
        }
        else if (objectToRemove == "showPlayer")
        {
            funeralLevelManager.ShowPlayerSprite();
        }
        else if (objectToRemove == "talkedToNick")
        {
            funeralLevelManager.TalkedToNickFirst();
        }
        else if (objectToRemove == "talkedTosennah")
        {
            funeralLevelManager.TalkedToSennahFirst();
        }
        else if (objectToRemove == "toMarcusRoomNight")
        {
            funeralLevelManager.ToMarcusRoomNight();
        }
        else if (objectToRemove == "toAnimalLevel")
        {
            levelSwitchingHandlerScript.ToAnimalLevel();
        }
        else if (objectToRemove == "talkedToDebra")
        {
            policeStationDayManager.TalkedToD();
        }
        else if (objectToRemove == "talkedToSennah")
        {
            policeStationDayManager.TalkedToS();
        }
        else if (objectToRemove == "talkedToNickPoliceStation")
        {
            levelSwitchingHandlerScript.FireLevelDone();
        }
        else if (objectToRemove == "giveNickEvidence")
        {
            AnimalLevelPoliceStation.GaveEvidenceToNick();
        }
        else if (objectToRemove == "giveSennahEvidence")
        {
            AnimalLevelPoliceStation.GaveEvidenceToSennah();
        }
        else if (objectToRemove == "giveDebraEvidence")
        {
            AnimalLevelPoliceStation.GaveEvidenceToDebra();
        }
        else if (objectToRemove == "pickUpCayote")
        {
            animalNightLevel.cayoteHasBeenAquired();
        }
        else if (objectToRemove == "pickedUpHare")
        {
            animalNightLevel.hareHasBeenAquired();
        }
        else if (objectToRemove == "holeOneChosen")
        {
            animalNightLevel.HoleOneSelected();
        }
        else if (objectToRemove == "holeTwoChosen")
        {
            animalNightLevel.HoleTwoSelected();
        }
        else if (objectToRemove == "holeThreeChosen")
        {
            animalNightLevel.HoleThreeSelected();
        }
        else if (objectToRemove == "shovelPickedUp")
        {
            animalNightLevel.ShovelAquired();
        }
        else if (objectToRemove == "animalDayDone")
        {
            levelSwitchingHandlerScript.AnimalDayDone();
        }
        else if (objectToRemove == "toHumanLevel")
        {
            levelSwitchingHandlerScript.ToHumanLevel();
            playerWalkingScript.ActivateCurve();
        }
        else if (objectToRemove == "toolTaken")
        {
            humanLevelManagerScript.ToolTaken();
        }
        else if (objectToRemove == "cabinDoorUnlocked")
        {
            humanLevelManagerScript.DoorUnlocked();
        }
        else if (objectToRemove == "finalRoomDoor")
        {
            playerWalkingScript.StopCurve();
            levelSwitchingHandlerScript.ToFinalLevel();
        }
        else if (objectToRemove == "invisDoor")
        {
            finalLevelManagerScript.RemoveInvisBarrier();
        }
        else if (objectToRemove == "turnScreenBlack")
        {
            finalLevelManagerScript.TurnScreenBlack();
        }
        else if (objectToRemove == "toFinalLevelHomeNight")
        {
            levelSwitchingHandlerScript.FinalLevelNight();
        }
        else if (objectToRemove == "theNextMorning")
        {
            levelSwitchingHandlerScript.NextMorning();
        }
        else if (objectToRemove == "showSennahHitbox")
        {
            levelSwitchingHandlerScript.SennahHitbox();
        }
        else if (objectToRemove == "finalBlackScreen")
        {
            levelSwitchingHandlerScript.FinalBlackScreen();
        }
        else if (objectToRemove == "toCredits")
        {
            levelSwitchingHandlerScript.EndCreditCoroutine();
        }
        else
        {
            Debug.Log("Something Else");
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        int index = 0;
        //enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for( int i = index; i < choices.Length;  i++ )
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectedFirstChoice());
    }

    public void MakeChoice(int choiceIndex)
    {
        if(canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
        }
       
    }

    private IEnumerator SelectedFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
}
