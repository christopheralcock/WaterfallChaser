using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    //public float volume = 0.13f;
    public float volume = 1;


    void Awake()
    {
        AudioListener.volume = this.volume;
        this.MarkMusicNonDestroy();
    }


    void MarkMusicNonDestroy()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Music"))
        {
            DontDestroyOnLoad(obj);
        }
    }

}
