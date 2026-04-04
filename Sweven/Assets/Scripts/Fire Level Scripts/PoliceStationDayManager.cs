using UnityEngine;

public class PoliceStationDayManager : MonoBehaviour
{
    public GameObject nickGoAway;
    public GameObject nick;

    private bool talkedtosennah;
    private bool talkedtodebra;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (talkedtosennah == true && talkedtodebra == true)
        {
            TalkedToBoth();
        }
    }

    public void TalkedToBoth()
    {
        nickGoAway.SetActive(false);
        nick.SetActive(true);
    }

    public void TalkedToS()
    {
        talkedtosennah= true;
    }
    public void TalkedToD()
    {
        talkedtodebra = true;
    }
}
