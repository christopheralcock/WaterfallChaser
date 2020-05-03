using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flinger : MonoBehaviour
{
    private Chaser chaser;
    private ChaserPointer chaserPointer;

    // Start is called before the first frame update
    void Awake()
    {
        chaser = FindObjectOfType<Chaser>();
        chaserPointer = FindObjectOfType<ChaserPointer>();
    }

    private void OnMouseDown()
    {
        chaserPointer.Warp(GetMousePosition());
    }

    private void OnMouseDrag()
    {
        chaserPointer.Warp(GetMousePosition());
    }

    private void OnMouseUp()
    {
        chaser.Jump(GetMousePosition());
        chaserPointer.Reset();
        Debug.Log("flinger onmouseup");
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }
}
