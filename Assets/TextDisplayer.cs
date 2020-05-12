using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayer : MonoBehaviour
{

    public LevelController levelController;
    public Text complete;
    public Text scrollInstructions;
    public Text flingInstructions;

    // Update is called once per frame
    void Update()
    {
        if (levelController.levelComplete)
        {
            complete.text = @"
CONGRATULATIONS!

LEVEL COMPLETE!

THANKS A LOT FOR PLAYING

GIVE CHRIS SOME FEEDBACK
@chrisalcockdev";
        }

        if (levelController.firstFlingHappened)
        {
            flingInstructions.text = null;
        }

        if (levelController.firstScrollHappened)
        {
            scrollInstructions.text = null;
        }
    }
}