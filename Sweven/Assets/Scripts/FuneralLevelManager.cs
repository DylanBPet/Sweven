using UnityEngine;
using UnityEngine.Events;

public class FuneralLevelManager : MonoBehaviour
{
    public GameObject blackBox;

    public GameObject Sennah;
    public GameObject SennahTalkedToNickFirst;

    public GameObject Nick;
    public GameObject NickTalkedToSennahFirst;

    public GameObject funeralScene;
    public GameObject roomNight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPlayerSprite()
    {
        blackBox.SetActive(false);
    }

    public void TalkedToSennahFirst()
    {
        Nick.SetActive(false);
        NickTalkedToSennahFirst.SetActive(true);
    }
    public void TalkedToNickFirst()
    {
        Sennah.SetActive(false);
        SennahTalkedToNickFirst.SetActive(true);
    }

    public void ToMarcusRoomNight()
    {
        funeralScene.SetActive(false);
        roomNight.SetActive(true);
    }
}
