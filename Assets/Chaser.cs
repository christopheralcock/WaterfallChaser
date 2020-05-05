using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{

    public int speedMultiplier = 300;
    public bool flingable = false;
    public bool stationary = false;
    private Rigidbody2D chaserRigidbody;
    public LaunchArcRenderer lar;

    public void Awake()
    {
        this.chaserRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump(Vector2 mousePosition)
    {
        if (flingable == true)
        { 
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = currentPosition - mousePosition;
            GetComponent<Rigidbody2D>().AddForce(direction * speedMultiplier);
            flingable = false;
            lar.colour = lar.red;
        }
    }

    public void MakeFlingable()
    {
        this.flingable = true;
        }

    private void OnCollisionEnter2D()
    {
        this.MakeFlingable();
    }


    public bool IsStationary()
    {
       return this.chaserRigidbody.velocity.magnitude <= 0.1;
    }


}
