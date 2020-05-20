using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject body;
    public GameObject wing;
    public bool flapUp = true;
    public float gravity = 0;
    public float flapSpeed = 0.03f;
    public float flapExtent = 2;

    // Start is called before the first frame update
    void Start()
    {
        //body = 
        body.GetComponent<Rigidbody2D>().gravityScale = gravity;
        wing.GetComponent<Rigidbody2D>().gravityScale = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        Flap();
        FlyLeft();
    }

    void FlyLeft()
    {
        this.transform.Translate(new Vector2(-0.01f,0));
    }


    void Flap()
    {
        var wingHeight = wing.transform.localScale.y;
        if (flapUp && wingHeight <= flapExtent)
        {
            wing.transform.localScale = new Vector2(1, wing.transform.localScale.y + flapSpeed);
        }
        if (wing.transform.localScale.y >= flapExtent)
        {
            flapUp = false;
        }
        if (!flapUp && wing.transform.localScale.y >= -flapExtent)
        {
            wing.transform.localScale = new Vector2(1, wing.transform.localScale.y - flapSpeed);
        }
        if (wing.transform.localScale.y <= -flapExtent)
        {
            flapUp = true;
        }
    }

    public void LoopAround()
    { 
        this.transform.Translate(new Vector2(17, 0));
    }
}
