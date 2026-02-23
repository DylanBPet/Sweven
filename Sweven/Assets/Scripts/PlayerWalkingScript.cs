using UnityEngine;

public class PlayerWalkingScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;

    public Animator animator;

    public Vector2 input;

    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("moveX", input.x);
        animator.SetFloat("moveY", input.y);

        transform.position += (Vector3) input * speed * Time.deltaTime;
    }
}
