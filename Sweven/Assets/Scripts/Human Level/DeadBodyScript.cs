using UnityEngine;

public class DeadBodyScript : MonoBehaviour
{
    public Transform player;

    private float playerposY;
    private float playerposX;

    private Vector2 deadBodyPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deadBodyPos = transform.position;
        


        transform.position = 
    }
}
