using UnityEngine;

public class EnterKeySpriteChange : MonoBehaviour
{
    private SpriteRenderer enterKeySr;
    public Sprite enterKeyWhite;
    public Sprite enterKeyBlack;

    public GameObject enterKey;
    private Vector3 startPos;
    private Vector3 endPos;

    private float time;

    private bool bounceBack = false;

    private float lerpTime = 0;

    public AnimationCurve curve;
    private float y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enterKeySr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //changing sprites
        time += 1 * Time.deltaTime;
        if(time <= 1)
        {
            enterKeySr.sprite = enterKeyWhite;
        }
        else if (time > 1 && time < 2)
        {
                enterKeySr.sprite = enterKeyBlack;
        }
        else
        {
            time = 0;
        }

        //the lerp
        if(bounceBack == true)
        {
            lerpTime += -1.2f * Time.deltaTime;
        }
        else if (bounceBack == false)
        {
            lerpTime += 1.2f * Time.deltaTime;
        }

        if(lerpTime <= 0)
        {
            lerpTime = 0;
            bounceBack = false;
        } 
        else if (lerpTime >= 1)
        {
            lerpTime = 1;
            bounceBack = true;
        }

        //the animation curve
        y = curve.Evaluate(lerpTime);
        enterKey.transform.position = Vector2.Lerp(startPos, endPos, y);
    }

    public void NewEnterIconPosition()
    {
        startPos = enterKey.transform.position;
        startPos.y += 0.1f;

        endPos = enterKey.transform.position;
        endPos.y -= 0.1f;
    }
}
