using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaunchArcRenderer : MonoBehaviour
{

    LineRenderer lr;

    public float velocity =  10;
    public float angle = 45;
    public int resolution = 10;

    float g; // force of gravity on the y axis
    float radianAngle;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics2D.gravity.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        RenderArc();
    }

    // populating line renderer settings
    void RenderArc()
    {
        lr.positionCount = resolution + 1;
        lr.SetPositions(CalculateArcArray());

    }

    Vector3[] CalculateArcArray()
    {
        var arcArray = new Vector3[resolution+1];
        this.radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;
        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }

        return arcArray;
    }

    private Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        // the 0 below is because the tutorial i'm working from assumes lands on same level as launched from, which might not be what i want. should be y with an sub 0
        float y = 0 + (x * Mathf.Tan(radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle))));
        //float y = x + 1;
        return new Vector3(x, y);  
    }


}
