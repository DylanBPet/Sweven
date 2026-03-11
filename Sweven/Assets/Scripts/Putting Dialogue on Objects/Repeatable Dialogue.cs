using UnityEngine;
using UnityEngine.InputSystem;

public class RepeatableDialogue : MonoBehaviour
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

    //the sprite renderer for the button so it is clickable
    public SpriteRenderer button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //can do the same dialogue more than once
        if (hitBox.bounds.Contains(player.position) == true)
        {
            startingDialogueVisual.SetActive(true);
            if (button.bounds.Contains(mousePos) && Mouse.current.leftButton.wasPressedThisFrame)
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
