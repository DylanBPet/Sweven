using UnityEngine;

public class FinalConfrontationScript : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer overlayHitbox;
    public GameObject overlay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (overlayHitbox.bounds.Contains(player.transform.position))
        {
            overlay.SetActive(false);
        }
        else
        {
            overlay.SetActive(true);
        }
    }
}
