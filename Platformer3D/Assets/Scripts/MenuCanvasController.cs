using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //This function is gonna activate when the play button is pressed
    public void OnPlayButton()
    {
       
        SceneManager.LoadScene(1);
    }

    //This function is gonna activate when the quit button is pressed
    public void OnQuitButton()
    {
        //This will quit out the application
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
