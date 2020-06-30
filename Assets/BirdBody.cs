using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBody : MonoBehaviour
{
    public Bird bird;

    void OnBecameInvisible()
    {
        Debug.Log("bird invisible!");
        
        bird.LoopAround();
    }
}
