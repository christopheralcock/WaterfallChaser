using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserPointer : MonoBehaviour
{

    Chaser chaser;
    Vector3 currentPosition;
    public float size = 2;

    public void Awake()
    {
        chaser = FindObjectOfType<Chaser>();
    }

    public void Warp(Vector3 mousePosition)
    {
        currentPosition = this.transform.position;
        Debug.Log("jump");

        //set size of pointer
        var direction = currentPosition - mousePosition;
        float warpFactor = Mathf.Sqrt((direction.x * direction.x) + (direction.y * direction.y));
        Vector2 warpVector = new Vector2(1, warpFactor * this.size); 
        this.transform.localScale = warpVector;

        // and set direction
        var rot = this.transform.rotation.eulerAngles;
        float angle = (Mathf.Atan2(currentPosition.y - mousePosition.y, currentPosition.x - mousePosition.x) * 180 / Mathf.PI) - 90; 
        rot.z = angle;
        this.transform.rotation = Quaternion.Euler(rot);
    }

    public void Reset()
    {
        this.transform.localScale = new Vector2(0,0);
     }
}
