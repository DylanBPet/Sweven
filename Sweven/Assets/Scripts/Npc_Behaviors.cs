using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Ink.Runtime;

public class Npc_Behaviors : MonoBehaviour
{
    //player position
    public Transform player;

    //npc canvas
    public GameObject startingDialogueVisual;

    //invis hitbox around npc
    public SpriteRenderer hitBox;


    //the ink file
    public TextAsset inkJSON;

    //dialogue manager script
    public InkManager inkManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hitBox.bounds.Contains(player.position) == true && inkManager.finishedFirstDialogue == false)
        {
            startingDialogueVisual.SetActive(true);
            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                StartDialogue();
            }
        }
        else
        {
            startingDialogueVisual.SetActive(false);
        }

     
    }

    public void StartDialogue()
    {
        if(inkManager.dialogueIsPlaying == true)
        {
            return;
        }
        else
        {
            inkManager.EnterDialogueMode(inkJSON);
        }
           
    }
}
