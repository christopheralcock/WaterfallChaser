using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{

    public LevelController levelController;
    public Text completionMessage;
    bool completionMessagePresent = false;
    public Text scrollInstructions;
    bool scrollInstructionsPresent = false;
    public Text flingInstructions;
    bool flingInstructionsPresent = false;
    public NextLevelButton nextLevelButton;
    public RestartLevelButton restartLevelButton;
    public bool levelComplete = false;
    public string completionMessageString = @"
CONGRATULATIONS!

LEVEL COMPLETE!

THANKS A LOT FOR PLAYING

GIVE CHRIS SOME FEEDBACK
@chrisalcockdev";


    void Awake()
    {
        this.levelController = FindObjectOfType<LevelController>();
        this.nextLevelButton = FindObjectOfType<NextLevelButton>();
        this.nextLevelButton.gameObject.SetActive(false);
        this.restartLevelButton = FindObjectOfType<RestartLevelButton>();
        this.restartLevelButton.gameObject.SetActive(false);

        try
        {
            this.completionMessage = GameObject.FindGameObjectWithTag("CompletionMessage").GetComponent<Text>();
            this.completionMessagePresent = true;
        }
        catch (System.Exception ex)
        {
            Debug.Log("no completion message, and that is fine");
            Debug.Log(ex.ToString());
        }

        try
        {
            this.scrollInstructions = FindObjectOfType<ScrollInstructions>().GetComponent<Text>();
            this.scrollInstructionsPresent = true;
        }
        catch (System.Exception ex) {
            Debug.Log("no scroll instructions, and that is fine");
            Debug.Log(ex.ToString());
        }

        try
        {
            this.flingInstructions = FindObjectOfType<FlingInstructions>().GetComponent<Text>();
            this.flingInstructionsPresent = true;
        }
        catch (System.Exception ex)
        {
            Debug.Log("no fling instructions, and that is fine");
            Debug.Log(ex.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (levelController.readyToRestart)
        {
            this.restartLevelButton.gameObject.SetActive(true);
        }

        if (levelController.levelComplete && !this.levelComplete)
        {
            nextLevelButton.gameObject.SetActive(true);
            this.levelComplete = true;
            if (completionMessagePresent)
            {
                completionMessage.text = completionMessageString;
            }
        }

        if (levelController.firstFlingHappened && this.flingInstructionsPresent)
        {
            flingInstructions.text = null;
        }

        if (levelController.firstScrollHappened && this.scrollInstructionsPresent)
        {
            scrollInstructions.text = null;
            scrollInstructionsPresent = false;
        }

        if (levelController.readyToRestart)
        {

        }
    }
}