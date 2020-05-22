using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoulder : MonoBehaviour
{
    public bool raising = true;
    public float flailSpeed = 0.03f;
    public float flailExtent = 1;
    public float flailUpperExtent;
    public float flailLowerExtent;
    Vector2 originalPosition;


    private void Start()
    {
        originalPosition = transform.position;
        flailUpperExtent = transform.position.y + flailExtent;
        flailLowerExtent = transform.position.y - flailExtent;

    }

    // Update is called once per frame
    void Update()
    {
        Flail();
    }

    void Flail()
    {
        //Debug.Log("flailin");
        var scale = this.transform.position;
        var height = scale.y;
        if (raising && height <= flailUpperExtent)
        {
            transform.position = new Vector2(transform.position.x, height + flailSpeed);
        }
        if (height >= flailUpperExtent)
        {
            raising = false;
        }
        if (!raising && height >= flailLowerExtent)
        {
            transform.position = new Vector2(transform.position.x, height - flailSpeed);
        }
        if (height <= flailLowerExtent)
        {
            raising = true;
        }
    }

}
