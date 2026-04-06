using UnityEngine;

public class HumanLevelManagerScript : MonoBehaviour
{
    public GameObject frontDoor;
    public GameObject frontDoorUnlocked;

    public SpriteRenderer benchOverlayHitbox;
    public GameObject benchOverlay;

    public Transform playerPos;

    public bool doorOpen;

    public SpriteRenderer toNextLevel;

    public LevelSwitchingHandler levelSwitchingHandler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (benchOverlayHitbox.bounds.Contains(playerPos.transform.position))
        {
            benchOverlay.SetActive(false);
        }
        else
        {
            benchOverlay.SetActive(true);
        }

        if (doorOpen == true)
        {
            if (toNextLevel.bounds.Contains(playerPos.transform.position))
            {
                levelSwitchingHandler.EndOfHumanLevelHomeMorning();
            }
        }
    }

    public void ToolTaken()
    {
        frontDoor.SetActive(false);
        frontDoorUnlocked.SetActive(true);
    }

    public void DoorUnlocked()
    {
        doorOpen = true;
        frontDoorUnlocked.SetActive(false);
    }
}
