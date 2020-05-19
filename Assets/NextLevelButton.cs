using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public LevelController levelController;

    private void Awake()
    {
        // there should only be one LevelController in any given circumstance
        Debug.Log("awaking nextlevel button");
        this.levelController = FindObjectOfType<LevelController>();
        Debug.Log("attaching " + levelController.ToString());
    }

    public void NextLevel()
    {
        Debug.Log("CLICKED NEXT LEVEL BUTTON");
        levelController.NextLevel();
    }
}
