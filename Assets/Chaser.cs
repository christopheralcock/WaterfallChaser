using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{

    public int speedMultiplier = 300;
    public bool flingable = false;
    public bool stationary = false;
    private Rigidbody2D chaserRigidbody;
    private AudioSource audioSource;

    public void Awake()
    {
        this.chaserRigidbody = GetComponent<Rigidbody2D>();
        this.audioSource = GetComponent<AudioSource>();
    }

    public void Jump(Vector2 mousePosition, Vector3 direction)
    {
        if (flingable == true)
        {
            chaserRigidbody.AddForce(direction * speedMultiplier);
            flingable = false;
        }
    }

    public void MakeFlingable()
    {
        this.flingable = true;
        }

    private void OnCollisionEnter2D()
    {
        this.MakeFlingable();
        audioSource.Play();
    }

    private void OnCollisionStay2D()
    {
        this.MakeFlingable();
    }

    private void OnCollisionExit2D()
    {
        this.flingable = false;    
        }

    public bool IsStationary()
    {
       return this.chaserRigidbody.velocity.magnitude <= 0.1;
    }


}
