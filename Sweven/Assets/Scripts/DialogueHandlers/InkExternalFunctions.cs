using UnityEngine;

public class InkExternalFunctions : MonoBehaviour
{
    public GameObject fireNightFire;
    public GameObject fireDayTown;
    public GameObject marcusHome;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    public void ChangeScene(string sceneName)
    {
        if(sceneName == "fireNightFire")
        {
            fireNightFire.SetActive(true);
            marcusHome.SetActive(false);
        }
        else if (sceneName == "fireDayTown")
        {
            marcusHome.SetActive(false);
            fireDayTown.SetActive(true);
        }
        else if (sceneName == "marcusGome")
        {
            marcusHome.SetActive(true);
            fireDayTown.SetActive(false);
            fireNightFire.SetActive(false);
        }
    }

}
