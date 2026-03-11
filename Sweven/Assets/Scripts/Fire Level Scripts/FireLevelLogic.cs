using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class FireLevelLogic : MonoBehaviour
{
    public EnterKeySpriteChange enterKeyScript;

    /////////////////////////////////////////////Rock//////////////////////////
    public GameObject rockEnterKey;
    //hitbox to show the rock button
    public SpriteRenderer rockHitbox;
    //tracks if the rock is picked up
    private bool rockIsPickedUp = false;
    //the rock game object (will be hidden if picked up)
    public GameObject rock;

    ////////////////////////////////////////Window/////////////////////////////////
    //hitbocx to show the window buttons
    public SpriteRenderer windowHitbox;
    //used when the window is broken
    public GameObject window;
    //shown when the window is broken
    public GameObject escapePath;
    public GameObject windowEnterKey;
 

    //////////////////////////Vent/////////////////////////
    public SpriteRenderer ventHitbox;
    public GameObject ventEnterKey;

    //////////////////////Emergincy Door//////////////////
    public SpriteRenderer emergHitbox;
    public GameObject emergincyDoorEnterKey;

    ///////////////////////////////PLAYER///////////////////
    public Transform player;

    ////////////////Level LEAVEL//////
    public SpriteRenderer levelLeave;
    //the fire level game object that will be hidden
    public GameObject fireLevel;
    //the next scene we will switch to
    public GameObject MarcusRoom;
    //the day scene
    public GameObject fireDayTown;

    ///////////////////////////Ink EVERYTHING I will need////////////////////////////////
    //InkManger scrupt
    public InkManager inkManager;

    //the ink file that will play
    public TextAsset windowText;
    public TextAsset windowBreakText;

    public TextAsset ventText;

    public TextAsset emergDoorText;

    public TextAsset rockText;

    //the emergincy door itself
    public GameObject emergDoor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RestartLevel();
    }

    // Update is called once per frame
    void Update()
    {

        /////////////////////////ROCK/////////////////////////////
        //if the player is within the hitbox, show the rock pickup text
        if(rockHitbox.bounds.Contains(player.position))
        {
            if(rockIsPickedUp == false)
            {
                PlayerCanInteract(rockHitbox, rockEnterKey, RockPressed);
            }
        }

        ///////////////////////////////////Window////////////////////////

        //When button is activate
         else if (windowHitbox.bounds.Contains(player.position))
        {
            PlayerCanInteract(windowHitbox, windowEnterKey, WindowInspect);
        }


        ///////////////////////////////////////////Vent////////////////////////////////

        else if (ventHitbox.bounds.Contains(player.position))
        {
            PlayerCanInteract(ventHitbox, ventEnterKey, VentInspect);
        }

        ///////////////////////////emergincy door///////////////////////////////
        else if (emergHitbox.bounds.Contains(player.position))
        {
            PlayerCanInteract(emergHitbox, emergincyDoorEnterKey, EmergDoorText);
        }
        else
        {
            enterKeyScript.enterKey.SetActive(false);
        }

        if (inkManager.dialogueIsPlaying == true)
        {
            enterKeyScript.enterKey.SetActive(false);
        }

        if (levelLeave.bounds.Contains(player.position))
        {
            //all other scenes will be false
            fireLevel.SetActive(false);
            fireDayTown.SetActive(false);

            //go to marcus room
            MarcusRoom.SetActive(true);
            player.position = Vector2.zero;
        }
       

      

    }

    public void PlayerCanInteract(SpriteRenderer hitbox, GameObject location, Action doThis)
    {
        if(hitbox.bounds.Contains(player.position))
        {
            enterKeyScript.enterKey.SetActive(true);
            enterKeyScript.enterKey.transform.position = location.transform.position;
            enterKeyScript.NewEnterIconPosition();

            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                doThis();
            }
            
        }
        else
        {
            enterKeyScript.enterKey.SetActive(false);
        }
    }

    //this happeneds when the rock button has been pressed
    public void RockPressed()
    {
        inkManager.EnterDialogueMode(rockText);
            rockIsPickedUp = true;
            rock.SetActive(false);
       
    }

    //happeneds when the window inspect button is pressed
    public void WindowInspect()
    {
        if (rockIsPickedUp == false)
        {
            inkManager.EnterDialogueMode(windowText);
        }
        else
        {
            inkManager.EnterDialogueMode(windowBreakText);
        }
 
    }

    public void WindowBreak()
    {
      
         window.SetActive(false);
         escapePath.SetActive(true);
    }

    public void VentInspect()
    {
        inkManager.EnterDialogueMode(ventText);
    }

    public void EmergDoorText()
    {
        inkManager.EnterDialogueMode(emergDoorText);
    }

    public void EmergDoorOpen()
    {
        emergDoor.SetActive(false);
    }

    public void RestartLevel()
    {

        //reset everything in the level
        rockIsPickedUp = false;
        escapePath.SetActive(false);

        //redraw everything in level
        rock.SetActive(true);
        emergDoor.SetActive(true);
        window.SetActive(true);


    }

}
