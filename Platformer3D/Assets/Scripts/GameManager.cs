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

    //A static objects methods will be treated as static, meaning you can use the object as a way to call those methods in other classes

    //This is going to be true if the game is paused and false if it is not
    public bool paused = false;


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

        //This updates the UI text
        GameUI.instance.UpdateScoreText();
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
        GameUI.instance.SetEndScreen(true);
    }

    //This function gets called when we fail a level
    public void GameOver()
    {
        //Calls the end screen function from game ui
        GameUI.instance.SetEndScreen(false);
    }

  
    
    // Update is called once per frame
    void Update()
    {
       
    }
}
