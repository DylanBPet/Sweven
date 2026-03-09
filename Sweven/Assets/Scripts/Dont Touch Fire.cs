using UnityEngine;
using UnityEngine.InputSystem;

public class DontTouchFire : MonoBehaviour
{

    public Transform playerPos;
    public SpriteRenderer[] fires;

    //the deathScreen screen
    public GameObject deathScreen;

    //things to hide when player dies
    public GameObject player;

    //the respawn "button" but its actually just a square cause i cannot press the button because of the dialogue code
    public SpriteRenderer respawnButton;
    public GameObject showButton;

    //where you will be respawned
    private Vector2 respawnPoint = Vector2.zero;

    //is the player dead?
    public bool playerDead = false;

    //the script that controls the levels logic
    public FireLevelLogic fireLevelScript;

    //Enter Key
    public GameObject enterIcon;
    public GameObject enterIconPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Respawn(respawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < fires.Length; i++)
        {
            if (fires[i].bounds.Contains(playerPos.position))
            {
                PlayerDeath();
            }
        }

        if(playerDead == true)
        {
            enterIcon.transform.position = enterIconPosition.transform.position;
            enterIcon.SetActive(true);

            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                Respawn(respawnPoint);
            }
        }

    }
    
    public void PlayerDeath()
    {
        
        //hide player
        player.SetActive(false);
        //show the button
       showButton.SetActive(true);
        //show a death screen
        deathScreen.SetActive(true);
        //the player has died
        playerDead = true;
        
    }

    public void Respawn(Vector2 respawn)
    {

        //show player
        player.SetActive(true);
        //hide death screen
        deathScreen.SetActive(false);
        //hide the button
        showButton.SetActive(false);

        fireLevelScript.RestartLevel();

        //respawn player at respawn point
        playerPos.position = respawnPoint;

        //hides the enter key
        enterIcon.SetActive(false);
    }

}
