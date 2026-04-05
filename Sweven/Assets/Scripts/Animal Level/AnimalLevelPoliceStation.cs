using UnityEngine;

public class AnimalLevelPoliceStation : MonoBehaviour
{
    public GameObject policeStationLevel;
    public GameObject humanLevelNight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GaveEvidenceToNick()
    {
        ToHome();
    }
    public void GaveEvidenceToSennah()
    {
        ToHome();
    }
    public void GaveEvidenceToDebra()
    {
        ToHome();
    }

    public void ToHome()
    {
        policeStationLevel.SetActive(false);
        humanLevelNight.SetActive(true);
    }

}
