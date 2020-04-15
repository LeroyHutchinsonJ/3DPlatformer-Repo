using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    //This is a variable that is going to keep track of the score
    public int score;

    //With the static type I will be able to call this class in other scripts without having to create an object of it, using this game object as a type will allow me to call non static methods as well
    public static GameManager instance;

    private void Awake()
    {
        //So this is a way for checking for duplicate game objects, if there is a game object in the scene and it is not this one, destroy it
        if (instance != null && instance != this)
        {
            //Destroy gameObject
            Destroy(gameObject);
        }
        else
        {
            //Otherwise instance equal this
            instance = this;

            //I need to maintain this game object so that our scores will transfer between scenes
            DontDestroyOnLoad(gameObject);
        }
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
