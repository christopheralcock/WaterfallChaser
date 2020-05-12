using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    private void Awake()
    {
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

        if (chaser.col.IsTouching(goalCollider) && chaser.IsStationary()){
            this.SetLevelComplete();
        }
    }

    void SetLevelComplete()
    {
        this.levelActive = false;
        Debug.Log("LEVEL COLMPLETEEE");
        this.levelComplete = true;
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
}
