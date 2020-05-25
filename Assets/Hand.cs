using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : ChaserKiller
{
    public Rigidbody2D rigidBody;

    private void Start()
    {
        this.rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(new Vector2(0, Mathf.Abs(GetYForce())));
    }


    float GetYForce()
    {
        return Random.Range(-150, 150);
    }

    float GetXForce()
    {
        return Random.Range(-150, 150);
    }

    void ApplyRandomForce()
    {
        var x = GetXForce();
        var y = GetYForce();
        Debug.Log("random force applied: " + x + "," + y);
        this.rigidBody.AddForce(new Vector2(x,y));
    }


    private void Update()
    {
        var random = Random.Range(0, 100);
        if (random > 97)
        {
            ApplyRandomForce();
        }
    }
}
