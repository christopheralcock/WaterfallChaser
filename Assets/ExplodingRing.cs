using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingRing : MonoBehaviour
{
    public float defaultSpeed = 1f;
    public float speed = 0.5f;
    public bool exploding = false;

    private void Awake()
    {
        speed = defaultSpeed;
        this.GetComponent<SpriteRenderer>().color = Color.clear;
        //this.gameObject.SetActive(false);
        Explode();
    }

    public void Explode()
    {
        Debug.Log("explode called");
        this.GetComponent<SpriteRenderer>().color = Color.red;
        //this.gameObject.SetActive(true);
        this.exploding = true;
    }

    void Update()
    {
        if (this.exploding)
        {
            Debug.Log("ring exploding");
            this.transform.localScale = new Vector2(
                this.transform.localScale.x + this.speed, 
                this.transform.localScale.y + this.speed
                );
        }
    }
}
