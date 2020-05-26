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


    void Awake()
    {
        if (!basslineInitialised)
        {
            Instantiate(bassline);
            AudioListener.volume = this.volume;
            //MarkMusicNonDestroy();
            DontDestroyOnLoad(FindObjectOfType<ConstantMusic>());
            //Debug.Log("marking " + bassline.gameObject.ToString() + " don't destroy on load");
            //DontDestroyOnLoad(bassline.gameObject);
            basslineInitialised = true;
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
