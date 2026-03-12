using UnityEngine;

public class LevelSwitchingHandler : MonoBehaviour
{
    //objects to get removed
    public GameObject roomDoor;

    //player object
    public GameObject player;

    //hitboxes to take you somewhere else
    public GameObject outsideDoorHitbox;

    //to calculate distance between things
    public float distance;

    //levels
    public GameObject fireNightFire;
    public GameObject fireDayTown;
    public GameObject marcusRoomDay;
    public GameObject marcusRoomNight;
    public GameObject endDemoScreen;

    private bool doorIsGone = false;

    //scripts to call
    public MarcusHomeNightLevelLogic marcusHomeNightLevelLogicScript;
    public PuttingDialogueOnObjects puttingDialogueOnObjectsScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(doorIsGone)
        {
            //if the player hits the invisible hitbox outside of the door, take them to the daytime level
            distance = Vector2.Distance(player.transform.position, outsideDoorHitbox.transform.position);
            if (distance < 1f)
            {
                SwitchToFireLevel();
                doorIsGone = false;
            }
        }
        
    }


    
    public void RemoveObject(string objectToRemove)
    {
        //if there is no tag, do nothing
        if(objectToRemove == "none")
        {
            return;
        }
        else
        {
            return;
        }
    }

    public void GoToSleep()
    {
        //switch level to dream fire
        marcusRoomNight.SetActive(false);
        fireNightFire.SetActive(true);
    }

    public void SwitchToFireLevel()
    {
        fireDayTown.SetActive(true);
        marcusRoomDay.SetActive(false);
    }

    public void RoomDoor()
    {
        //remove the door in marcus room
        roomDoor.SetActive(false);
        doorIsGone = true;

        //destroy the enter key
        puttingDialogueOnObjectsScript.DeleteList();
    }

    public void EndDemo()
    {
        //switch scene to end screen
        fireDayTown.SetActive(false);
        endDemoScreen.SetActive(true);
    }
}
