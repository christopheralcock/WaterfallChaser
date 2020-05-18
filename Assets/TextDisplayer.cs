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
    public GameObject nextLevelButton;
    public bool levelComplete = false;


    void Awake()
    {
        nextLevelButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelController.levelComplete && !this.levelComplete)
        {
//            complete.text = @"
//CONGRATULATIONS!

//LEVEL COMPLETE!

//THANKS A LOT FOR PLAYING

//GIVE CHRIS SOME FEEDBACK
//@chrisalcockdev";
            nextLevelButton.SetActive(true);
            this.levelComplete = true;
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