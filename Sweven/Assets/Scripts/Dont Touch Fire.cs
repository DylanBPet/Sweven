using UnityEngine;
using UnityEngine.InputSystem;

public class DontTouchFire : MonoBehaviour
{

    public Transform playerPos;
    public SpriteRenderer[] fires;

    //the deathScreen screen
    public GameObject deathScreen;
    public GameObject allFire;
    public GameObject player;

    //the respawn "button" but its actually just a square cause i cannot press the button because of the dialogue code
    public SpriteRenderer respawnButton;
    public GameObject showButton;

    //where you will be respawned
    private Vector2 respawnPoint = Vector2.zero;

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

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if(respawnButton.bounds.Contains(mousePos) && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Respawn(respawnPoint);
        }

    }
    
    public void PlayerDeath()
    {
        //hide fire
        allFire.SetActive(false);
        //hide player
        player.SetActive(false);
        //show the button
       showButton.SetActive(true);
        //show a death screen
        deathScreen.SetActive(true);
    }

    public void Respawn(Vector2 respawn)
    {
        //show fire
        allFire.SetActive(true);
        //show player
        player.SetActive(true);
        //hide death screen
        deathScreen.SetActive(false);
        //hide the button
        showButton.SetActive(false);

        //respawn player at respawn point
        playerPos.position = respawnPoint;
    }
}
