using UnityEngine;

public class EnterKeySpriteChange : MonoBehaviour
{
    public SpriteRenderer enterKey;
    public Sprite enterKeyWhite;
    public Sprite enterKeyBlack;


    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        time += 1 * Time.deltaTime;
        if(time <= 2)
        {
            enterKey.sprite = enterKeyWhite;
        }
        else if (time > 2 && time < 3)
        {
                enterKey.sprite = enterKeyBlack;
        }
        else
        {
            time = 0;
        }
    }
}
