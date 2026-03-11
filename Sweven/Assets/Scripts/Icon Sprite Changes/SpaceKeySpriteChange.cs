using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SpaceKeySpriteChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image spaceKey;
    public Sprite spaceKeyWhite;
    public Sprite spaceKeyBlack;

    private float time;
    private float lerpTime;

    private Transform spaceKeyTransform;
    private Vector3 startPos;
    private Vector3 endPos;

    public AnimationCurve curve;
    private float y;

    private bool bounceBack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spaceKeyTransform = GetComponent<Transform>();

        startPos = spaceKeyTransform.position;
        startPos.y -= 3f;

        endPos = spaceKeyTransform.position;
        endPos.y += 3f;
    }

    // Update is called once per frame
    void Update()
    {

        time += 1 * Time.deltaTime;
        if (time <= 1)
        {
            spaceKey.sprite = spaceKeyWhite;
        }
        else if (time > 1 && time < 2)
        {
            spaceKey.sprite = spaceKeyBlack;
        }
        else
        {
            time = 0;
        }

        //the lerp
        if (bounceBack == true)
        {
            lerpTime += -1.2f * Time.deltaTime;
        }
        else if (bounceBack == false)
        {
            lerpTime += 1.2f * Time.deltaTime;
        }

        if (lerpTime <= 0)
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
        spaceKeyTransform.position = Vector2.Lerp(startPos, endPos, y);
    }
}
