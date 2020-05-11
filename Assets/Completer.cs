using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Completer : MonoBehaviour
{

    public LevelController levelController;
    public Text text;

    // Update is called once per frame
    void Update()
    {
        if (levelController.levelComplete)
        {
            text.text = @"
CONGRATULATIONS!

LEVEL COMPLETE!

THANKS A LOT FOR PLAYING

GIVE CHRIS SOME FEEDBACK
@chrisalcockdev";
        }
    }
}