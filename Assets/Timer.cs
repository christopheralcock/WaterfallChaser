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

    // Update is called once per frame
    void Update()
    {
        if (!levelController.levelComplete)
        {
            this.realTime += Time.deltaTime;
            this.frameCount++;
            this.frameRate = this.realTime / this.frameCount;

            float contactSeconds = levelController.contactTimer * this.frameRate;
            int score = (int)Mathf.Max(this.maxScore - contactSeconds, 0);
            text.text = $"{score.ToString()} points";
            Debug.Log((int)this.realTime);
        }
    }
}
