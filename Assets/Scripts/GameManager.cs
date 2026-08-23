using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public float timeRemaining = 300; //5 min
    public bool timerOn = false;

    public string sceneName;


    public TMP_Text Timer;
    public GameObject GameOverScreen;
    public GameObject InGameUI;
    public GameObject LevelComplete;


    ManagerScene SM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameOverScreen.gameObject.SetActive(false);
        InGameUI.gameObject.SetActive(true);
        LevelComplete.gameObject.SetActive(false);


        SM = FindFirstObjectByType<ManagerScene>();
        Scene currentScene = SceneManager.GetActiveScene ();

        sceneName = currentScene.name;


    }

    // Update is called once per frame
    void Update()
    {
         if (timerOn)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerOn = false;
                GameOver();
            }
        }
    }

       void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void GameOver()
    {
        Debug.Log("GameOver!");
        isGameOver = true;
        InGameUI.gameObject.SetActive(false);
        GameOverScreen.gameObject.SetActive(true);
        Invoke("LoadSceneAgain", 5f);
    }   

    public void LoadSceneAgain()
    {
        SceneManager.LoadScene(0);
    } 
    public void RestartLevel()
    {
        if(sceneName == "LevelOne")
            {
                SM.LevelOne();
            }
            else if(sceneName == "LevelTwo")
            {
                SM.LevelTwo();
            }
             else if(sceneName == "LevelThree")
            {
                SM.LevelThree();
            }
    }

}
