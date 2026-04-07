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
    public GameObject fire_policeStation;
    public GameObject marcusRoomNightAnimalLevel;
    public GameObject animalLevel;

    public GameObject animalDay;
    public GameObject animalPoliceStation;

    public GameObject humanMarcusRoom;
    public GameObject humanLevel;
    public GameObject humanLevelPoliceStatoin;
    public GameObject endOfHumanLevelHomeMorning;
    public GameObject finalLevelPoliceStation;
    public GameObject finalConfrontation;

    public PlayerWalkingScript playerWalkingScript;

    private bool doorIsGone = false;

    public GameObject sennahHumanLevelHitbox;

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
        fire_policeStation.SetActive(true);
    }

    public void ToAnimalLevel()
    {
        marcusRoomNightAnimalLevel.SetActive(false);
        animalLevel.SetActive(true);
    }

    public void FireLevelDone()
    {
        fire_policeStation.SetActive(false);
        marcusRoomNightAnimalLevel.SetActive(true);
    }

    public void AnimalDayDone()
    {
        animalDay.SetActive(false);
        animalPoliceStation.SetActive(true);
    }

    public void ToHumanLevel()
    {
        humanMarcusRoom.SetActive(false);
        humanLevel.SetActive(true);
    }




    public void EndOfHumanLevelHomeMorning()
    {
        humanLevel.SetActive(false);
        endOfHumanLevelHomeMorning.SetActive(true);
        playerWalkingScript.StopCurve();
    }

    public void EndOfHumanLevelPoliceStation()
    {
        endOfHumanLevelHomeMorning.SetActive(false);
        humanLevelPoliceStatoin.SetActive(true);
    }

    public void ToFinalLevel()
    {
         endOfHumanLevelHomeMorning.SetActive(false);
        humanLevelPoliceStatoin.SetActive(true);
    }

    public void NextMorning()
    {
        humanLevelPoliceStatoin.SetActive(false);
        finalLevelPoliceStation.SetActive(true);
    }

    public void FinalLevelNight()
    {
        finalLevelPoliceStation.SetActive(false);
        finalConfrontation.SetActive(true);
        player.transform.position = (new Vector2(-6, 0));
    }

    public void SennahHitbox()
    {
        sennahHumanLevelHitbox.SetActive(true);
    }
}
