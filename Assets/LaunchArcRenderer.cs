using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaunchArcRenderer : MonoBehaviour
{

    LineRenderer lr;
    public GameObject source;

    public float velocity =  1000;
    public float angle = 315;
    public float pastYFactor = 1.5f; // the amount of x you go past your initial Y - ie line goes on further 
    public int resolution = 20;
    public Color colour;
    float magicNumberThatWorks = 4; // no idea yet why 4 is the factor that sizes the line up to match the path


    float g; // force of gravity on the y axis
    float radianAngle;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics2D.gravity.y);
        this.transform.position = source.transform.position;
        lr.positionCount = 0;
        this.SetLineReady(false);
    }

    public void RenderArcPublic(float inputVelocity, float inputAngle, Vector3 inputOrigin)
    {
        this.velocity = inputVelocity * this.magicNumberThatWorks;
        this.angle = inputAngle;
        this.transform.position = inputOrigin;
        RenderArc();
    }

    // populating line renderer settings
    void RenderArc()
    {
        lr.material.color = this.colour;
        lr.positionCount = resolution + 1;
        lr.SetPositions(CalculateArcArray());
    }

    Vector3[] CalculateArcArray()
    {
        var arcArray = new Vector3[resolution+1];
        this.radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = ((velocity * velocity * Mathf.Sin(2 * radianAngle)) / g) * pastYFactor;
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
        x = x + this.transform.position.x;
        y = y + this.transform.position.y;
        return new Vector3(x, y, 10);

    }

    public void SetLineReady(bool ready)
    {
        if (ready)
        {
            this.colour = Color.green;
        }
        else
        {
            this.colour = Color.white;
        }
    }
}
