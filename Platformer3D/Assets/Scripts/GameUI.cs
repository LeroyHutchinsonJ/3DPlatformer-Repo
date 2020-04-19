using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    //End scene variables
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScreenHeader;
    public TextMeshProUGUI endScreenScoreText;
    public GameObject endScreen;

    //This is for the pause screen
    public GameObject pauseScreen;

    //I should create an instance so that I can access this classes methods from other objects as well
    public static GameUI instance;

    private void Awake()
    {
        instance = this;
    }
    //This function is called to update the score

    public void TogglePauseScreen(bool pause)
    {

        pauseScreen.SetActive(pause);
    }

    public void UpdateScoreText()
    {
        //This should set the text of the scoreText
        scoreText.text = "Score: " + GameManager.instance.score;
    }

    public void OnResumeBtn()
    {
        GameManager.instance.TogglePauseGame();
    }

    //This gets called when the player wins or dies
    public void SetEndScreen(bool hasWon)
    {
        //This activates the game object(end screen)
        endScreen.SetActive(true);

        //This is going to set the text of the end screen score
        endScreenScoreText.text = "<b>Score</b>\n" + GameManager.instance.score;

        //If the player has won
        if(hasWon)
        {
            //This sets the end screen header text and color
            endScreenHeader.text = "<b>You Win!</b>";
            endScreenHeader.color = Color.green;
        }
        else if(hasWon == false)
        {
            //This sets the game over text and color
            endScreenHeader.text = "<b>Game Over!</b>";
            endScreenHeader.color = Color.red;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This function will be called when the restart button is pressed
    public void OnRestartButton()
    {
        GameManager.instance.levelEnd = false;

        SceneManager.LoadScene(1);
    }

    //This function will be called when the menu button is pressed
    public void OnMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
