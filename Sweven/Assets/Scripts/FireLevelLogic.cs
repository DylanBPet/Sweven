using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class FireLevelLogic : MonoBehaviour
{
    
    /////////////////////////////////////////////Rock//////////////////////////
    //the rock button
    public SpriteRenderer rockButton;
    //hitbox to show the rock button
    public SpriteRenderer rockHitbox;
    //game object rock button (used to hide/show it)
    public GameObject gORockButton;
    //tracks if the rock is picked up
    private bool rockIsPickedUp = false;
    //the rock game object (will be hidden if picked up)
    public GameObject rock;

    ////////////////////////////////////////Window/////////////////////////////////
    //the window inspect button
    public SpriteRenderer windowInspectButton;
    //the window break button
    public SpriteRenderer windowBreakButton;
    //hitbocx to show the window buttons
    public SpriteRenderer windowHitbox;
    //these will be used to hide/show the window button game objects
    public GameObject gOWindowInspectButton;
    public GameObject gOWindowBreakButton;
    //used when the window is broken
    public GameObject window;
    //shown when the window is broken
    public GameObject escapePath;
    //tracks if the window has been broken
    private bool isWindowBroken = false;

    //////////////////////////Vent/////////////////////////
    public SpriteRenderer ventButton;
    public SpriteRenderer ventHitbox;
    public GameObject gOVentButton;

    //////////////////////Emergincy Door//////////////////
    public SpriteRenderer emergDoorButton;
    public SpriteRenderer emergDoorOpenButton;
    public SpriteRenderer emergHitbox;
    public GameObject gOEmerDoorButton;
    public GameObject gOEmerDoorOpenButton;

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
    public TextAsset ventText;
    public TextAsset emergDoorText;

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
        //tracking if the rock pick up button was pressed, if it is, switch rockIspickedup to true and rock dissapeares
        IsButtonPressed(rockButton, RockPressed);
        //if the player is within the hitbox, show the rock pickup button
        IsPlayerInHitbox(rockHitbox, gORockButton, gORockButton);

        ///////////////////////////////////Window////////////////////////
        IsButtonPressed(windowInspectButton, WindowInspect);
        IsButtonPressed(windowBreakButton, WindowBreak);
        //show the buttons
        IsPlayerInHitbox(windowHitbox, gOWindowInspectButton, gOWindowInspectButton);
        if(rockIsPickedUp == true)
        {
            IsPlayerInHitbox(windowHitbox, gOWindowBreakButton, gOWindowBreakButton);
        }
        else
        {
            gOWindowBreakButton.SetActive(false);
        }

        ///////////////////////////////////////////Vent////////////////////////////////
        IsButtonPressed(ventButton, VentInspect);
        IsPlayerInHitbox(ventHitbox, gOVentButton, gOVentButton);

        ///////////////////////////emergincy door///////////////////////////////
        IsButtonPressed(emergDoorButton, EmergincyDoorInspect);
        IsButtonPressed(emergDoorOpenButton, EmergDoorOpen);
        IsPlayerInHitbox(emergHitbox, gOEmerDoorButton, gOEmerDoorOpenButton);
        

        if(isWindowBroken == true)
        {
            if(levelLeave.bounds.Contains(player.position))
            {
                //all other scenes will be false
                fireLevel.SetActive(false);
                fireDayTown.SetActive(false);

                //go to marcus room
                MarcusRoom.SetActive(true);
                player.position = Vector2.zero;
            }
        }

      

    }

    public void IsButtonPressed(SpriteRenderer button, Action doThis)
    {
        //getting the mousepos
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //if the button contains mouse pos, and the left button was pressed, do something
        if (button.bounds.Contains(mousePos) && Mouse.current.leftButton.wasPressedThisFrame)
        {
            doThis();
        }
    }


    public void IsPlayerInHitbox(SpriteRenderer hitbox, GameObject button, GameObject button1)
    {
        if(hitbox.bounds.Contains(player.position))
        {
            button.SetActive(true);
            button1.SetActive(true);
        }
        else
        {
            button.SetActive(false);
            button1.SetActive(false);
        }
    }

    //this happeneds when the rock button has been pressed
    public void RockPressed()
    {
        if (rockHitbox.bounds.Contains(player.position))
        {
            rockIsPickedUp = true;
            rock.SetActive(false);
        }
       
    }

    //happeneds when the window inspect button is pressed
    public void WindowInspect()
    {
        if (windowHitbox.bounds.Contains(player.position))
        {
            inkManager.EnterDialogueMode(windowText);
        }
 
    }

    public void WindowBreak()
    {
      
         window.SetActive(false);
         isWindowBroken = true;
         escapePath.SetActive(true);
    }

    public void VentInspect()
    {
        if (ventHitbox.bounds.Contains(player.position))
        {
            inkManager.EnterDialogueMode(ventText);
        }
    }

    public void EmergincyDoorInspect()
    {
        if (emergHitbox.bounds.Contains(player.position))
        {
            inkManager.EnterDialogueMode(emergDoorText);
        }
    }

    public void EmergDoorOpen()
    {
        emergDoor.SetActive(false);
    }

    public void RestartLevel()
    {

        //reset everything in the level
        rockIsPickedUp = false;
        isWindowBroken = false;
        gOEmerDoorButton.SetActive(false);
        gORockButton.SetActive(false);
        gOVentButton.SetActive(false);
        gOWindowBreakButton.SetActive(false);
        gOWindowInspectButton.SetActive(false);
        escapePath.SetActive(false);

        //redraw everything in level
        rock.SetActive(true);
        emergDoor.SetActive(true);
        window.SetActive(true);


    }

}
