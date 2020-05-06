using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public float volume = 0.13f;

    void Awake()
    {
        AudioListener.volume = this.volume;
    }


}
