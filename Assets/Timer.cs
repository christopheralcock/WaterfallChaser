using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public LevelController levelController;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = (levelController.contactTimer/60).ToString();
    }
}
