using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ManagerScene : MonoBehaviour
{
    public string sceneName;


    public bool completedLevelOne;
    public bool completedLevelTwo;

    public bool Play = false;

    PlayerInput PI;
    PlayerFear PF;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        sceneName = currentScene.name;


        PI = FindFirstObjectByType<PlayerInput>();
        PF = FindFirstObjectByType<PlayerFear>();

         if(sceneName == "LevelThree" ||sceneName == "LevelTwo")
        {
            PF.DarkLevel = false;
        }
        else if(sceneName == "LevelOne")
        {
            PF.DarkLevel = true;
        }
  
        

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Continue()
    {
        if(sceneName == "LevelOne")
        {
            LevelTwo();
        }
        if(sceneName == "LevelTwo")
        {
            LevelThree();
        }
    }

      public void HubWorld()
    {         
        SceneManager.LoadSceneAsync(4);
    }

    public void LevelOne()
    {
        SceneManager.LoadSceneAsync(1);
    }
        public void LevelTwo()
    {
        SceneManager.LoadSceneAsync(2);
    }
        public void LevelThree()
    {
        SceneManager.LoadSceneAsync(3);

    }
     public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
