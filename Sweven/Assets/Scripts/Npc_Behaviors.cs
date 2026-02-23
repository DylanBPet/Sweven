using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Npc_Behaviors : MonoBehaviour
{
    //player position
    public Transform player;

    //npc canvas
    public GameObject npcUI;

    //invis hitbox around npc
    public SpriteRenderer hitBox;

    //sprite renderer for stupid UI above npc
    public SpriteRenderer startDialogueButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hitBox.bounds.Contains(player.position) == true)
        {
            npcUI.SetActive(true);
        }
        else
        {
            npcUI.SetActive(false);
        }

     
    }

    public void StartDialogue()
    {
        Debug.Log("Dialogue started");
    }
}
