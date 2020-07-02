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
        cameraMover = FindObjectOfType<CameraMover>();
    }

    private void OnMouseDown()
    {
        if (!chaser.dead)
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
                NeutralisePointerAndArc();
            }
        }
    }

    private void OnMouseDrag()
    {
        if (!chaser.dead)
        {
            if (MouseIsBelowBall())
            {
                this.UpdatePointerAndArc();
                lar.RenderArcTracer();

            }
            else
            {
                cameraMover.MoveUp(cameraMover.voluntarySpeed);
                NeutralisePointerAndArc();
            }
        }
    }

    private void OnMouseUp()
    {
        if (!chaser.dead)
        {
            if (MouseIsBelowBall() && !levelController.levelComplete)
            {
                levelController.firstFlingHappened = true;
                chaser.Jump(CalculateDirection());
                // why calculate direction for one and calculate angle for other? is this why they decouple?
                chaserPointer.Reset();
                PitchHandler.Play(audioSource, 1, "flinger");
                lar.SetLineReady(false);

            }
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


        if (chaser.flingable && !levelController.levelComplete)
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
        return Vector3.Angle(new Vector3(1,0,0), this.CalculateDirection());
        // is the below implementation what's wrong with the iphone? can i find a better direction -> angle calc?
        //return (Mathf.Atan2(chaser.transform.position.y - GetMousePosition().y, chaser.transform.position.x - GetMousePosition().x) * 180 / Mathf.PI);
    }

    private void NeutralisePointerAndArc()
    {
        lar.RenderArcPublic(false);
        chaserPointer.Warp(0, 0);
    }
}
