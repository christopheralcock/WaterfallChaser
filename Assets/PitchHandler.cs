using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchHandler : MonoBehaviour
{
    public static PitchHandler Instance;
    private static float[] pitchArray = new float[] { 1.5f, 1.26f, 1, 1.12f};
    private static int pitchIterator = 0;


    private void Awake()
    {
        Instance = this;
    }

    public static void Play(AudioSource audioSource)
    {
        audioSource.pitch = ChoosePitch();
        audioSource.Play();
    }


    private static float ChoosePitch()
    {
        float pitch = pitchArray[pitchIterator % pitchArray.Length];
        pitchIterator += 1;
        return pitch;
    }

}
