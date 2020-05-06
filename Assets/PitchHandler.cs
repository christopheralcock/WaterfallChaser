using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchHandler : MonoBehaviour
{
    public static PitchHandler Instance;
    private static float[] pitchArray = new float[] { 1.5f, 1.26f, 1, 1.12f};
    private static int pitchIterator = 0;
    public static float maxVolume = 0.45f;


    private void Awake()
    {
        Instance = this;
    }

    public static void Play(AudioSource audioSource, float volume)
    {
        audioSource.pitch = ChoosePitch();
        audioSource.volume = Mathf.Min(volume/4, maxVolume);
        audioSource.Play();
    }


    private static float ChoosePitch()
    {
        float pitch = pitchArray[pitchIterator % pitchArray.Length];
        pitchIterator += 1;
        return pitch;
    }

}
