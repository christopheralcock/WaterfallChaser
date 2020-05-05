using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{

    public int speedMultiplier = 300;
    public bool flingable = false;

    public void Jump(Vector2 mousePosition)
    {
        if (flingable == true)
        { 
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = currentPosition - mousePosition;
            GetComponent<Rigidbody2D>().AddForce(direction * speedMultiplier);
            flingable = false;
        }
    }

    public void makeFlingable()
    {
        this.flingable = true;
        }

    private void OnCollisionEnter2D()
    {
        Debug.Log("collided");
        this.makeFlingable();
    }
}
