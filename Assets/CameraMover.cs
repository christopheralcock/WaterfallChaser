using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public float speed;
    public float defaultSpeed = 0.01f;
    public float voluntarySpeed = 0.05f;
    public Chaser chaser;
    public float movementSensitivity;
    public float defaultMovementSensitivity = 0.5f;


    private void Awake()
    {
        chaser = FindObjectOfType<Chaser>();
        this.speed = this.defaultSpeed;
        this.movementSensitivity = this.defaultMovementSensitivity;

    }

    void Update()
    {
        if (!chaser.flingable)
        {
            MoveUp(speed);
        }
    }

    public void MoveUp(float s)
    {
        transform.Translate(new Vector3(0, s));
    }
}
