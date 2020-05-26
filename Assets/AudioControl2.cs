using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioControl2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START: A BOUNTY, A JOY, FRESH AUDIOCONTROL2");
        //var constantMusics = FindObjectsOfType<ConstantMusic>();
        //Debug.Log("we got " + constantMusics.Length + " constant musics");
    }

    void Awake()
    {
        Debug.Log("AWAKE: A BOUNTY, A JOY, FRESH AUDIOCONTROL2");
        //var constantMusics = FindObjectsOfType<ConstantMusic>();
        //Debug.Log("we got " + constantMusics.Length + " constant musics");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded       : " + scene.name);
        Debug.Log(mode);
        CountConstantMusics(scene);
    }


    void CountConstantMusics(Scene scene)
    {
        Debug.Log("HEY HEY IT'S SATURDAT" + scene.name);
    }




}
