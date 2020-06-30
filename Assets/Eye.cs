using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Boss boss;
    public Chaser chaser;

    void Start()
    {
        boss = FindObjectOfType<Boss>();
        chaser = FindObjectOfType<Chaser>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("eye registers collision");
        //Debug.Log(collision.collider.ToString());

        if (collision.collider.Equals(chaser.GetComponent<Collider2D>()) && !chaser.dead)
        {
            Debug.Log("destroy boss called");
            boss.Destruct();
        }
    }

}
