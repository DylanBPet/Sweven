using UnityEngine;

public class AnimalNightLevel : MonoBehaviour
{
    private bool harePickedUp;
    private bool cayotePickedUp;
    public GameObject cayote;
    public GameObject hare;

    public GameObject hole1;
    public GameObject hole2;
    public GameObject hole3;

    public GameObject animalNightLevel;
    public GameObject animalDayLevel;

    public GameObject holeHitbox1;
    public GameObject holeHitbox2;
    public GameObject holeHitbox3;

    public bool shovelPickedUp;

    private int holeSelected;

    public GameObject shovel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shovelPickedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shovelPickedUp)
        {
            if (holeSelected == 1)
            {
                holeHitbox1.SetActive(true);
                holeHitbox2.SetActive(false);
                holeHitbox3.SetActive(false);
            }
            else if (holeSelected == 2)
            {
                holeHitbox1.SetActive(false);
                holeHitbox2.SetActive(true);
                holeHitbox3.SetActive(false);
            }
            else
            {
                holeHitbox1.SetActive(false);
                holeHitbox2.SetActive(false);
                holeHitbox3.SetActive(true);
            }
        }

    }

    public void hareHasBeenAquired()
    {
        harePickedUp = true;
        hare.SetActive(false);
        AnimalPickedUp();

    }
    public void cayoteHasBeenAquired()
    {
        cayotePickedUp = true;
        cayote.SetActive(false);
        AnimalPickedUp();
    }

    public void HoleOneSelected()
    {
        holeSelected = 1;
        AnimalNightDone();
    }
    public void HoleTwoSelected()
    {
        holeSelected = 2;
        AnimalNightDone();
    }
    public void HoleThreeSelected()
    {
        holeSelected = 3;
        AnimalNightDone();
    }
    public void AnimalNightDone()
    {
        animalNightLevel.SetActive(false);
        animalDayLevel.SetActive(true);
    }

    public void AnimalPickedUp()
    {
        if (harePickedUp && cayotePickedUp)
        {
            hole1.SetActive(true);
            hole2.SetActive(true);
            hole3.SetActive(true);
        }
    }

    public void ShovelAquired()
    {
        shovelPickedUp = true;
        shovel.SetActive(false);
    }
}
