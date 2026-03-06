using UnityEngine;

public class FireFakeAnimation : MonoBehaviour
{
    private SpriteRenderer fireSR;

    public Color fireRed;
    public Color fireOrange;

    private int colourA;
    public float changeSpeed;

    private Transform fireTran;

    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fireSR = GetComponent<SpriteRenderer>();
        fireTran = GetComponent<Transform>();
        startPos = fireTran.position;
    }

    // Update is called once per frame
    void Update()
    {

        if(colourA >= 0)
        {
            fireSR.color = fireRed;
        }
        else if(colourA <= 256)
        {
            fireSR.color = fireOrange;
        }

    }

    public void ChangeAlpha()
    {
        colourA--;
    }

}
