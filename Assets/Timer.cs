using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public LevelController levelController;
    public Text text;
    public int maxScore = 100;
    public float frameRate = 1/60;
    public float realTime = 0;
    public int frameCount = 0;
    public int score;
    public int lastNumberToTriggerMusicChange;
    public int contactSecondsBetweenMusicChanges = 8;

    // Update is called once per frame
    void Update()
    {
        if (!levelController.levelComplete)
        {
            this.realTime += Time.deltaTime;
            this.frameCount++;
            this.frameRate = this.realTime / this.frameCount;
            float contactSeconds = levelController.contactTimer * this.frameRate;
            this.score = (int)Mathf.Max(this.maxScore - contactSeconds, 0);
            text.text = $"{this.score.ToString()} points";
            if (this.score % this.contactSecondsBetweenMusicChanges == 0 && this.score != this.lastNumberToTriggerMusicChange)
            {
                this.ProgressMusic();
                this.lastNumberToTriggerMusicChange = this.score;
            }
        }
    }

    public void ProgressMusic()
    {
        AudioControl.musicStage++;
    }

}
