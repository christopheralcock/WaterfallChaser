using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public float volume = 1;
    public static bool basslineInitialised = false;
    public AudioSource bassline;
    //public bool BossLevel = false;
    //public static bool bossMusicInitialised = false;
    //public AudioSource bossMusic;
    public string existingMusicName;
    public string basslineName;


    void Awake()
    {
        if (!basslineInitialised)
        {
            StartCorrectMusic();
            basslineInitialised = true;
        }

        var existingMusic = FindObjectOfType<ConstantMusic>().GetComponent<AudioSource>();
        existingMusicName = existingMusic.clip.name;
        basslineName = this.bassline.clip.name;
        if (existingMusicName != basslineName)
        {
            Destroy(existingMusic.gameObject);
            StartCorrectMusic();
        }
    }

    void StartCorrectMusic()
    {
        Instantiate(bassline);
        AudioListener.volume = this.volume;
        MarkMusicNonDestroy();
    }

    void MarkMusicNonDestroy()
    {
        foreach (ConstantMusic obj in FindObjectsOfType<ConstantMusic>())
        {
            DontDestroyOnLoad(obj.gameObject);
        }
    }

}
