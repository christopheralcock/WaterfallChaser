using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelController : MonoBehaviour
{

    public Chaser chaser;
    public int contactTimer = 0;
    public Goal goal;
    public Collider2D goalCollider;
    private bool levelActive = true;
    public bool levelComplete = false;
    public bool firstFlingHappened = false;
    public bool firstScrollHappened = false;
    public AudioSource success;
    string sceneName;
    static int levelIndex;
    static public string[] levelList = { 
        "Intro", 
        "BabySteps", 
        "ElClassico",
        "Boss1",
        "Jungle", 
        "WoodForTrees",
        "SkiJump",
        "Boss1"
        };


    private void Awake()
    {
        this.success = FindObjectOfType<SuccessChime>().GetComponent<AudioSource>();
        Debug.Log("level controller awakens");
        sceneName = SceneManager.GetActiveScene().name;
        levelIndex = Array.IndexOf(levelList, sceneName);
        goal = FindObjectOfType<Goal>();
        goalCollider = goal.GetComponentsInChildren<Collider2D>()[0];
        chaser = FindObjectOfType<Chaser>();
    }


    private void Update()
    {
        if (chaser.flingable && this.levelActive)
        {
            contactTimer++;
        }

        if (chaser.dead)
        {
            Restart();
        }

        if (chaser.col.IsTouching(goalCollider) && chaser.IsStationary() && !levelComplete){
            this.SetLevelComplete();
        }
    }

    void SetLevelComplete()
    {
        this.levelActive = false;
        this.levelComplete = true;
        success.Play();
        //this.NextLevel();
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
    public void NextLevel()
    {
        levelIndex = (levelIndex +1)%levelList.Length;
        SceneManager.LoadScene(levelList[levelIndex]);
    }
}
