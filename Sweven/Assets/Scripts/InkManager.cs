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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    }

    // Update is called once per frame
    void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }

        if(Keyboard.current.spaceKey.wasPressedThisFrame)
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
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        textUI.SetActive(true);

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
            //set text for the current dialogue line
            dialogueText.text = currentStory.Continue();
            //display choices, if any, for this dialogue line
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
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
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    private IEnumerator SelectedFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
}
