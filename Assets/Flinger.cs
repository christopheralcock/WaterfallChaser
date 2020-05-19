using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flinger : MonoBehaviour
{
    private Chaser chaser;
    private ChaserPointer chaserPointer;
    public LaunchArcRenderer lar; 
    private AudioSource audioSource;
    public CameraMover cameraMover;
    public LevelController levelController;


    // Start is called before the first frame update
    void Awake()
    {
        chaser = FindObjectOfType<Chaser>();
        chaserPointer = FindObjectOfType<ChaserPointer>();
        chaserPointer.GetComponent<FixedJoint2D>().connectedBody = chaser.GetComponent<Rigidbody2D>();
        lar = FindObjectOfType<LaunchArcRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (MouseIsBelowBall())
        {
            this.UpdatePointerAndArc();
            PitchHandler.Play(audioSource, 1, "flinger");
        }
        else
        {
            levelController.firstScrollHappened = true;
            cameraMover.MoveUp(cameraMover.voluntarySpeed);
        }
    }

    private void OnMouseDrag()
    {
        if (MouseIsBelowBall())
        {
            this.UpdatePointerAndArc();
        }
        else
        {
            cameraMover.MoveUp(cameraMover.voluntarySpeed);
        }
    }

    private void OnMouseUp()
    {
        if (MouseIsBelowBall())
        {
            levelController.firstFlingHappened = true;
            chaser.Jump(GetMousePosition(), CalculateDirection());
            chaserPointer.Reset();
            PitchHandler.Play(audioSource, 1, "flinger");
            lar.SetLineReady(false);
        }
    }

    private bool MouseIsBelowBall()
    {
        return this.GetMousePosition().y < chaser.transform.position.y;
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void UpdatePointerAndArc()
    {
        if (chaser.flingable)
        {
            lar.SetLineReady(chaser.IsStationary());
            chaserPointer.Warp(CalculatePower(), CalculateAngle());
            lar.RenderArcPublic(CalculatePower(), CalculateAngle(), chaser.transform.position);
        }
    }

    private Vector3 CalculateDirection()
    {
        return chaser.transform.position - GetMousePosition();
    }

    private float CalculatePower()
    {
        var direction = CalculateDirection();
        return Mathf.Sqrt((direction.x * direction.x) + (direction.y * direction.y));
    }

    private float CalculateAngle()
    {
        return (Mathf.Atan2(chaser.transform.position.y - GetMousePosition().y, chaser.transform.position.x - GetMousePosition().x) * 180 / Mathf.PI);
    }
}
