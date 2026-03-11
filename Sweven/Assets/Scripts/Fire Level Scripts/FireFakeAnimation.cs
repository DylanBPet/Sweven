using UnityEngine;

public class FireFakeAnimation : MonoBehaviour
{
    private SpriteRenderer fireSR;

    private Transform fireTran;

    private Vector3 startPos;
    private Vector3 endPos;

    private int randomCol;
    private int randomChangeTime;

    private float time;

    public Color orange;
    public Color red;
    public Color yellow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireSR = GetComponent<SpriteRenderer>();
        fireTran = GetComponent<Transform>();
        startPos = fireTran.position;
        endPos = startPos;
        endPos.y += 2;
    }

    // Update is called once per frame
    void Update()
    {

        //lerp to a position that is slightly above its starting point
        if(time == 0)
        {
            time = Random.Range(0, 0.7f);
        }
        time += 0.5f * Time.deltaTime;
        fireTran.position = Vector2.Lerp(startPos, endPos, time);
        if(time > 1)
        {
            time = 0;
        }

        //as it lerps, it gets smaller and shakes side to side
        fireTran.localScale = Vector2.one * (-1 + time);


        //It changes to a random colour red, orange, yellow
        if(time >= 0.3)
        {
            fireSR.color = red;
        }
        if (time >= 0.6)
        {
            fireSR.color = yellow;
        }
        if (time >= 0.6)
        {
            fireSR.color = orange;
        }

    }
}
