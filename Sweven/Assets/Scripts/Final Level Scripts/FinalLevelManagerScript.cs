using UnityEngine;

public class FinalLevelManagerScript : MonoBehaviour
{
    public GameObject smallPoliceStation;
    public GameObject largePoliceStation;

    public SpriteRenderer stationFloor;
    public GameObject invisDoor;

    public GameObject player;

    public GameObject blackOverlay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stationFloor.bounds.Contains(player.transform.position))
        {
            largePoliceStation.SetActive(true);
            smallPoliceStation.SetActive(false);
            MovePlayer();
        }
    }

    public void RemoveInvisBarrier()
    {
        invisDoor.SetActive(false);
    }

    public void MovePlayer()
    {
        player.transform.position = new Vector2(0, -4);
    }

    public void TurnScreenBlack()
    {
        blackOverlay.SetActive(true);
    }

}
