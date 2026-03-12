using UnityEngine;

public class MarcusHomeNightLevelLogic : MonoBehaviour
{
    public GameObject player;

   // public LevelSwitchingHandler levelSwitchingHanderScript;

    public InkManager inkManagerScript;

    public TextAsset inkJSON;

    //levels
    public GameObject fireNightFire;
    public GameObject fireDayTown;
    public GameObject marcusRoomDay;
    public GameObject marcusRoomNight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BeginingOfGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(inkManagerScript.finishedFirstDialogue != true)
        {
            if (inkManagerScript.dialogueIsPlaying == true)
            {
                return;
            }
            else
            {
                inkManagerScript.textUI.SetActive(true);
                inkManagerScript.EnterDialogueMode(inkJSON);
            }
        }
    }

    public void BeginingOfGame()
    {
        player.transform.position = new Vector2(-4, 0);

        //fireNightFire.SetActive(false);

        marcusRoomNight.SetActive(true);

        //fireDayTown.SetActive(false);

        //marcusRoomNight.SetActive(false);
    }
}
