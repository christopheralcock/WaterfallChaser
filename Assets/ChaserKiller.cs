using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserKiller : MonoBehaviour
{
    public Chaser chaser;
    public List<ChaserKiller> allChaserKillers;

    // Start is called before the first frame update
    void Start()
    {
        chaser = FindObjectOfType<Chaser>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.Equals(chaser.GetComponent<Collider2D>()))
        {
            Debug.Log("should be killing chaser");
            chaser.dead = true;
        }

        //if (collision.gameObject.GetComponent<ChaserKiller>())
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
