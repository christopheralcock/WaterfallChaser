using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelController : MonoBehaviour
{

    public Chaser chaser;
    public int contactTimer = 0;
    public GameObject goal;
    public Collider2D goalCollider;
    private bool levelActive = true;
    public bool levelComplete = false;
    public bool firstFlingHappened = false;
    public bool firstScrollHappened = false;
    public AudioSource success;
    string sceneName;
    static int levelIndex;
    static public string[] levelList = { "Intro", "ElClassico" };


    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        levelIndex = Array.IndexOf(levelList, sceneName);
        goalCollider = goal.GetComponent<Collider2D>();
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
