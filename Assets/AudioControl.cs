using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public float volume = 1;
    public static bool initialised = false;
    public AudioSource bassline;

    void Awake()
    {
        if (initialised == false)
        {
            Debug.Log("initialising");
            Instantiate(bassline);
            AudioListener.volume = this.volume;
            MarkMusicNonDestroy();
            initialised = true;
            bassline = GameObject.FindWithTag("Bassline").GetComponent<AudioSource>();
        }
    }

    void MarkMusicNonDestroy()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Bassline"))
        {
            DontDestroyOnLoad(obj);
        }
    }
}
