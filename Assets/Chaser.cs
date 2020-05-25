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
    public float shrinkSpeed = 0.99f;

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
        if (!this.dead)
        {
            this.MakeFlingable();
            PitchHandler.Play(audioSource, this.chaserRigidbody.velocity.magnitude, "chaser");
        }
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
        this.stationary = this.IsBelowSpeed(0.1f);
        return this.stationary;
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
        //Debug.Log(cameraXExtent);
        if (this.firstAppearedOnScreen && this.IllegallyOutOfBounds())
        {
            Debug.Log("became invisible after being first acknowledged visible");
            this.dead = true;
        } 
    }

    bool IllegallyOutOfBounds()
    {
        var cameraXMaxExtent = FindObjectOfType<CameraMover>().transform.position.x + CameraExtensions.OrthographicBounds(FindObjectOfType<Camera>()).extents.x;
        var cameraXMinExtent = FindObjectOfType<CameraMover>().transform.position.x - CameraExtensions.OrthographicBounds(FindObjectOfType<Camera>()).extents.x;
        var cameraYMinExtent = FindObjectOfType<CameraMover>().transform.position.y - CameraExtensions.OrthographicBounds(FindObjectOfType<Camera>()).extents.y;
        var illegalX = (this.transform.position.x > cameraXMaxExtent || this.transform.position.x < cameraXMinExtent);
        var illegalY = this.transform.position.y < cameraYMinExtent;
        return illegalX || illegalY;
    }


    private void Update()
    {
        if (this.dead)
        {
            var size = this.transform.localScale;
            this.transform.localScale = new Vector3(size.x * shrinkSpeed, size.x * shrinkSpeed, size.x * shrinkSpeed);
        }
    }

}
