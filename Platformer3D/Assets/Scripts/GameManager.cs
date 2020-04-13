using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    //This is a variable that is going to keep track of the score
    public int score;


    //Instance?
    public static GameManager instance;

    private void Awake()
    {
        //This sets the instance
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //I made this function public so that other classes can access it
    public void AddScore(int scoreToGive)
    {
        score += scoreToGive;
    }

    //This code will activate when the level ends
    public void LevelEnd()
    {
        //Is this the last level? Check if the amount of available levels is equal to the current level +1, i add 1 because remember the level index starts at 0
        if(SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
        {
            //Display the win game screen
            WinGame();
        }
        else
        {
            //Load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //This function gets called when we finish all the levels
    public void WinGame()
    {

    }

    //This function gets called when we fail a level
    public void GameOver()
    {
        //Basically telling the level to restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
