using UnityEngine;

public class PlayerWalkingScript : MonoBehaviour
{
    //public Rigidbody2D rigidBody;

    public Animator animator;

    public Vector2 input;

    public float speed;

    public InkManager inkManager;

    public bool animcurveMovement;

    public AnimationCurve speedCurve;
    private float t;
    private float y;

    public GameObject deadBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
        //rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (animcurveMovement == false)
        {
            if (inkManager.dialogueIsPlaying == true)
            {
                input = (Vector2.zero);
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
            }
            else
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");

                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                transform.position += (Vector3)input * speed * Time.deltaTime;
            }
        }
        else if (animcurveMovement == true)
        {
            if (inkManager.dialogueIsPlaying == true)
            {
                input = (Vector2.zero);
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
            }
            else
            {

                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");

                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                y = speedCurve.Evaluate(t);
                transform.position += (Vector3)input * y * 3 * Time.deltaTime;

            }
        }
        if (t >= 1)
        {
            t = 0;
        }
    }

    public void ActivateCurve()
    {
        transform.position = new Vector2(-6, 0);
        deadBody.SetActive(true);
        animcurveMovement = true;
    }

    public void StopCurve()
    {
        animcurveMovement = false;
    }
}
