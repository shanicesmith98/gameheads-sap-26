using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ManagerScene : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject HubWorld;
    public string sceneName;
    public bool EndOfLevel = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        sceneName = currentScene.name;
        HubWorld.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(EndOfLevel)
        {
            if(sceneName == "LevelOne")
            {
                LevelTwo();
            }
            else if(sceneName == "LevelTwo")
            {
                LevelThree();
            }
             else if(sceneName == "SampleScene")
            {
                MainMenu();
            }
        }

    }

      public void LoadHubWorld()
    {
        StartMenu.gameObject.SetActive(false);
        HubWorld.gameObject.SetActive(true);
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
