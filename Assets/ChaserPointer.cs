using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserPointer : MonoBehaviour
{

    public Chaser chaser;
    public LaunchArcRenderer lar;
    Vector3 currentPosition;
    public float size = 100;

    public void Warp(Vector3 mousePosition)
    {
        currentPosition = this.transform.position;
        //set size of pointer
        var direction = currentPosition - mousePosition;
        float warpFactor = Mathf.Sqrt((direction.x * direction.x) + (direction.y * direction.y));
        Vector2 warpVector = new Vector2(1, warpFactor * this.size); 
        this.transform.localScale = warpVector;

        // and set direction
        var rot = this.transform.rotation.eulerAngles;
        float angle = (Mathf.Atan2(currentPosition.y - mousePosition.y, currentPosition.x - mousePosition.x) * 180 / Mathf.PI);
        rot.z = angle - 90;
        this.transform.rotation = Quaternion.Euler(rot);
        lar.RenderArcPublic(4*warpFactor, angle, this.currentPosition);

    }

    public void Reset()
    {
        this.transform.localScale = new Vector2(0,0);
     }
}
