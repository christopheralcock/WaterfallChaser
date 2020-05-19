using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cradle : MonoBehaviour
{

    public Color mainColour = Color.white;

    //public GameObject leftPart;
    //public GameObject rightPart;
    // Start is called before the first frame update
    void Start()
    {
        if (this is Goal)
        {
            Debug.Log("its a goal");
            this.mainColour = Goal.goalColour;
        }
        var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in spriteRenderers)
        {
            sr.color = mainColour;
        }


    }
}
