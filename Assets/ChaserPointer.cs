using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserPointer : MonoBehaviour
{
    public float size = 100;

    public void Warp(float warpFactor, float angle)
    {
            //set size of pointer
            Vector2 warpVector = new Vector2(1, warpFactor * this.size);
            this.transform.localScale = warpVector;

            // and set direction
            var rot = this.transform.rotation.eulerAngles;
            rot.z = angle - 90;
            this.transform.rotation = Quaternion.Euler(rot);
    }

    public void Reset()
    {
        this.transform.localScale = new Vector2(0,0);
     }
}
