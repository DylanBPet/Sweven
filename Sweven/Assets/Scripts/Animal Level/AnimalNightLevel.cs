using UnityEngine;

public class AnimalNightLevel : MonoBehaviour
{
    private bool harePickedUp;
    private bool cayotePickedUp;

    public GameObject hole1;
    public GameObject hole2;
    public GameObject hole3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (harePickedUp && cayotePickedUp)
        {
            hole1.SetActive(true);
            hole2.SetActive(true);
            hole3.SetActive(true);
        }
    }

    public void hareHasBeenAquired()
    {
        harePickedUp = true;
    }
    public void cayoteHasBeenAquired()
    {
        cayotePickedUp = true;
    }
}
