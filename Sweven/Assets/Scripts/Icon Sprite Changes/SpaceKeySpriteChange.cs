using UnityEngine;
using UnityEngine.UI;

public class SpaceKeySpriteChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Image spaceKey;
    public Sprite spaceKeyWhite;
    public Sprite spaceKeyBlack;


    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
    }
}
