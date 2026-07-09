using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerFear : MonoBehaviour //GameManager (I'm scared to rename the script)
{
    public int levelsCompleted;
    public bool DarkLevel = true;
    public float maxFear = 100f;
    public float currentFear;
    public bool isGameOver = false;
    public float timeRemaining = 300; //5 min
    public bool timerOn = false;


    public Slider FearSlider;
    public TMP_Text Timer;
    public TMP_Text GameOverText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentFear = 0;
        UpdateFearUI();
        GameOverText.gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        currentFear += damage;
        currentFear = Mathf.Clamp(currentFear, 0, maxFear);
        UpdateFearUI();        
    }

    void UpdateFearUI()
    {
        if(FearSlider != null)
        {
            FearSlider.value = currentFear / maxFear;
        }
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

      void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Update()
    {
        if(currentFear == maxFear)
        {
            GameOver();
        }
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
}









  



