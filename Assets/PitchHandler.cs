using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchHandler : MonoBehaviour
{
    public static PitchHandler Instance;
    private static float[] chaserPitchArray = new float[] { 1.5f, 1.26f, 1, 1.12f};
    private static int chaserPitchIterator = 0;
    private static float[] flingerPitchArray = new float[] { 1, 1.26f };
    private static int flingerPitchIterator = 0;
    public static float maxVolume = 0.45f;


    private void Awake()
    {
        Instance = this;
    }

    public static void Play(AudioSource audioSource, float volume, string objectType)
    {
        audioSource.pitch = ChoosePitch(objectType);
        audioSource.volume = Mathf.Min(volume/4, maxVolume);
        audioSource.Play();
    }


    private static float ChoosePitch(string objectType)
    {
        if (objectType == "chaser")
        {
            float pitch = chaserPitchArray[chaserPitchIterator % chaserPitchArray.Length];
            chaserPitchIterator += 1;
            return pitch;
        }
        if (objectType == "flinger")
        {
            float pitch = flingerPitchArray[flingerPitchIterator % flingerPitchArray.Length];
            flingerPitchIterator += 1;
            return pitch;
        }
        else
        {
            return 1;
        }
    }

}
