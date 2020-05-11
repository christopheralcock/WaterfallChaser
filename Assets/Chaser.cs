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
    public Collider2D col;

    bool firstAppearedOnScreen = false;
    public bool dead = false;

    public void Awake()
    {
        this.chaserRigidbody = GetComponent<Rigidbody2D>();
        this.audioSource = GetComponent<AudioSource>();
        this.col = GetComponent<Collider2D>();
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
        PitchHandler.Play(audioSource, this.chaserRigidbody.velocity.magnitude);
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
        return this.IsBelowSpeed(0.1f);
    }

    public bool IsBelowSpeed(float speed)
    {
        return this.chaserRigidbody.velocity.magnitude <= speed;
    }

    private void OnBecameVisible()
    {
        this.firstAppearedOnScreen = true;
    }


    private void OnBecameInvisible()
    {
        Debug.Log("became invisible");
        if (this.firstAppearedOnScreen) {
            Debug.Log("became invisible after being first acknowledged visible");
            this.dead = true;
        } 
    }

}
