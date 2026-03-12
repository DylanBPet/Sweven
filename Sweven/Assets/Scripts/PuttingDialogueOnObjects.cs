using Ink.Parsed;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PuttingDialogueOnObjects : MonoBehaviour
{
        //General
    //player position
    public Transform player;

    //invis hitbox around npc
    public SpriteRenderer invisibleHitBox;

        //Text Stuff
    //dialogue manager script
    public InkManager inkManager;
    //the ink file
    public TextAsset inkJSON;
    //the text ui
    public GameObject textUI;

        //Enter Key stuff
    //enter key script
    private EnterKeySpriteChange enterKeyScript;
    //the location of the new enter key spot
    public GameObject newIconLocation;
    //enter key Prefab
    public GameObject enterKeyPrefab;
    //keeping track of the spanwed in enter key
    private GameObject spawnedEnterKey;
    //enter key prefab LIST
    public List<GameObject> enterKeyList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        List<GameObject> EnterKeyList = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
            //moving enter key
        //if player is inside invisible hitbox
        if (invisibleHitBox.bounds.Contains(player.transform.position))
        {
                //instantiate the enter key
                //ONLY if list is equal to 1
            if(enterKeyList.Count < 1)
            {

                spawnedEnterKey = Instantiate(enterKeyPrefab, newIconLocation.transform.position, Quaternion.identity);
                enterKeyList.Add(spawnedEnterKey);

                for (int i = 0; i < enterKeyList.Count; i++)
                {
                    //get the script
                    enterKeyScript = enterKeyList[i].GetComponent<EnterKeySpriteChange>();

                    //change the position to the new position
                    enterKeyScript.enterKey.transform.position = newIconLocation.transform.position;
                    enterKeyScript.NewEnterIconPosition();
                }

            }

            //show/hide enter key if dialogue is playing
            //is REPETABLE
            if (inkManager.dialogueIsPlaying == true)
            {
                enterKeyList[0].gameObject.SetActive(false);
            }
            else if(inkManager.dialogueIsPlaying == false)
            {
                enterKeyList[0].gameObject.SetActive(true);
            }

            //Dialouge 
            //can do the same dialogue more than once
            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                textUI.SetActive(true);
                StartDialogue();
            }
        }
        else
        {
                //remove the instantiates 
            if (enterKeyList.Count > 0)
            {
                DeleteList();
            }
        }

    }

    public void DeleteList()
    {
        //delete the enter key
        for (int i = enterKeyList.Count - 1; i >= 0; i--)
        {
            spawnedEnterKey = enterKeyList[i];
            enterKeyList.Remove(spawnedEnterKey);

            Destroy(spawnedEnterKey);
        }
    }

    public void StartDialogue()
    {
        if (inkManager.dialogueIsPlaying == true)
        {
            return;
        }
        else
        {
            
            inkManager.EnterDialogueMode(inkJSON);
        }

    }
}
