using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public float speed;
    public float defaultSpeed = 0.01f;
    public Chaser chaser;
    public float movementSensitivity;
    public float defaultMovementSensitivity = 0.5f;


    private void Awake()
    {
        this.speed = this.defaultSpeed;
        this.movementSensitivity = this.defaultMovementSensitivity;

    }

    void Update()
    {
        if (!chaser.IsBelowSpeed(0.5f))
        {
            MoveUp();
        }
    }

    void MoveUp()
    {
        transform.Translate(new Vector3(0, speed));
    }
}
