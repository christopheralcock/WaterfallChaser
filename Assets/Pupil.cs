using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pupil : MonoBehaviour
{
    public bool opening = true;
    public float winkSpeed = 0.03f;
    public float openExtent = 1;


    // Update is called once per frame
    void Update()
    {
        Wink();
    }

    void Wink()
    {
        //Debug.Log("winkin");
        var scale = this.transform.localScale;
        var openness = scale.y;
        if (opening && openness <= openExtent)
        {
            transform.localScale = new Vector2(1, openness + winkSpeed);
        }
        if (openness >= openExtent)
        {
            opening = false;
        }
        if (!opening && openness >= 0)
        {
            transform.localScale = new Vector2(1, openness - winkSpeed);
        }
        if (openness <= 0)
        {
            opening = true;
        }
    }
}
