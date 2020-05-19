using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    public LevelController levelController;
    public Text completionMessage;
    public Text scrollInstructions;
    public Text flingInstructions;
    public NextLevelButton nextLevelButton;
    public bool levelComplete = false;


    void Awake()
    {
        this.levelController = FindObjectOfType<LevelController>();
        this.completionMessage = GameObject.FindGameObjectWithTag("CompletionMessage").GetComponent<Text>();
        this.nextLevelButton = FindObjectOfType<NextLevelButton>();
        this.nextLevelButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelController.levelComplete && !this.levelComplete)
        {
//            completionMessage.text = @"
//CONGRATULATIONS!

//LEVEL COMPLETE!

//THANKS A LOT FOR PLAYING

//GIVE CHRIS SOME FEEDBACK
//@chrisalcockdev";
            nextLevelButton.gameObject.SetActive(true);
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