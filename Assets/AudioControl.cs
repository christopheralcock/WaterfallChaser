using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    //public float volume = 0.13f;
    public float volume = 1;
    public static bool initialised = false;
    //public GameObject music;
    public AudioSource major;
    //public AudioSource minor;
    public bool initialisedSoICanSeeIt = initialised;
    public static int musicStage = 0;
    public int updateMusicStage = 0;
    public float[] pitchOrder = new float[] {
        440.00f, // A
        369.99f, // F#m
        587.33f, // D
        493.88f, // Bm
        392.00f, // G
        329.63f, // Em
        523.25f, // C
        440.00f, // Am
        349.23f, // F
        587.33f, // Dm
        466.16f, // Bb
        392.00f, // Gm
        311.13f, // Eb
        523.25f, // Cm
        415.30f, // Ab
        349.23f, // Fm
        554.37f, // C#
        466.16f, // Bbm
        369.99f, // F#
        311.13f, // D#m
        493.88f, // B
        415.30f, // G#m
        329.63f, // E
        554.37f // C#m
    };
    public string[] majorMinor = new string[] { "major", "minor" };

    void Awake()
    {
        if (initialised == false)
        {
            Debug.Log("initialising");
            Instantiate(major);
            //Instantiate(minor);
            AudioListener.volume = this.volume;
            //DontDestroyOnLoad(music);
            MarkMusicNonDestroy();
            initialised = true;
            major = GameObject.FindWithTag("Major").GetComponent<AudioSource>();
            //minor = GameObject.FindWithTag("Minor").GetComponent<AudioSource>();
        }
    }

    void MarkMusicNonDestroy()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Major"))
        {
            DontDestroyOnLoad(obj);
        }
        //foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Minor"))
        //{
        //    DontDestroyOnLoad(obj);
        //}
    }


    private void Update()
    {
        if (this.updateMusicStage != musicStage)
        {
            //this.ProgressM    usic();
            this.updateMusicStage = musicStage;
        }
    }

    void ProgressMusic()
    {
        //var pitchindex = musicStage % pitchOrder.Length;
        //var majorMinorIndex = musicStage % majorMinor.Length;
        //var pitch = pitchOrder[pitchindex]/440;
        //var chord = majorMinor[majorMinorIndex];
        //Debug.Log(pitch);
        //Debug.Log(chord);
        //if (chord == "major")
        //{
        //    major.pitch = pitch;
        //    major.Play();
        //}
        //if(chord == "minor")
        //{
        //    minor.pitch = pitch;
        //    minor.Play();
        //}




        // take current music and fade it down slowly and stop

        // set noncurrent music at the required pitch and start
    }

}
