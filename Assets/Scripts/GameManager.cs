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

    public TMP_Text Timer;
    public TMP_Text GameOverText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameOverText.gameObject.SetActive(false);

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
        GameOverText.gameObject.SetActive(true);
        GameOverText.text = "GAME OVER!";
        Invoke("LoadSceneAgain", 1f);
    }   

    void LoadSceneAgain()
    {
        SceneManager.LoadScene(0);
    } 

}
