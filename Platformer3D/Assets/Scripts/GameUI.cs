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

    //I should create an instance so that I can access this classes methods from other objects as well
    public static GameUI instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
