using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    Eye eye;
    public ExplodingRing explodingRing;

    void Start()
    {
        eye = FindObjectOfType<Eye>();   
    }

    public void Destruct()
    {
        Destroy(gameObject);
        Instantiate(explodingRing, eye.transform.position, Quaternion.identity);
    }

}
