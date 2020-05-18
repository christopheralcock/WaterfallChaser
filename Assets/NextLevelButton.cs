using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public LevelController levelController;

    public void NextLevel()
    {
        Debug.Log("CLICKED NEXT LEVEL BUTTON");
        levelController.NextLevel();
    }
}
