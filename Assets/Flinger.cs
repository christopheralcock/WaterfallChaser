using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flinger : MonoBehaviour
{
    private Chaser chaser;
    private ChaserPointer chaserPointer;
    public LaunchArcRenderer lar;

    // Start is called before the first frame update
    void Awake()
    {
        chaser = FindObjectOfType<Chaser>();
        chaserPointer = FindObjectOfType<ChaserPointer>();
    }

    private void OnMouseDown()
    {
        this.UpdatePointerAndArc();
    }

    private void OnMouseDrag()
    {
        this.UpdatePointerAndArc();
    }

    private void OnMouseUp()
    {
        chaser.Jump(GetMousePosition(), CalculateDirection());
        chaserPointer.Reset();
        lar.SetLineReady(false);
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
