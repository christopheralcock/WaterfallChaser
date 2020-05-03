using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{

    public int speedMultiplier = 300;

    public void Jump(Vector2 mousePosition)
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Debug.Log("jump");
        Vector2 direction = currentPosition - mousePosition;
        GetComponent<Rigidbody2D>().AddForce(direction * speedMultiplier);
    }
}
