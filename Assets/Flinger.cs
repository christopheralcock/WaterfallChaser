using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flinger : MonoBehaviour
{
    private Chaser chaser;

    // Start is called before the first frame update
    void Awake()
    {
        chaser = FindObjectOfType<Chaser>();
        Debug.Log("found chaser");
        Debug.Log(chaser);
    }

    private void OnMouseDown()
    {
        Debug.Log("that mouse is down");
    }

    private void OnMouseUp()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        chaser.Jump(mousePosition);
        Debug.Log("flinger onmouseup");
    }
}
