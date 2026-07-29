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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HubWorld.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

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
}
