﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    // Start is called before the first frame update


    public string lol = "lol";
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(CalculateDirection() * 800);
        Debug.Log("added force to tracer");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 CalculateDirection()
    {
        return transform.position - GetMousePosition();
    }


    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}


