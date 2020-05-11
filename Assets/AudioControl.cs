using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    //public float volume = 0.13f;
    public float volume = 1;
    public static bool initialised = false;
    public GameObject music;
    public bool initialisedSoICanSeeIt = initialised;

    void Awake()
    {
        if (initialised == false)
        {
            Debug.Log("initialising");
            Instantiate(music);
            AudioListener.volume = this.volume;
            //DontDestroyOnLoad(music);
            MarkMusicNonDestroy();
            initialised = true;
        }
    }

    void MarkMusicNonDestroy()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Music"))
        {
            DontDestroyOnLoad(obj);
        }
    }

}
