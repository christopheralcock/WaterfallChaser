using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : ChaserKiller
{

    public float speed = 7;
    public float angle = 0;

    void Update()
    {
        var rot = this.transform.rotation.eulerAngles;
        angle = angle+speed;
        rot.z = angle;
        this.transform.rotation = Quaternion.Euler(rot);
    }
}
