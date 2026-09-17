using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutSceneManager : MonoBehaviour
{
    PlayerInput PI;
    Animator anim;
    public GameObject EvilMC;
    public GameObject GameWonScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PI = FindFirstObjectByType<PlayerInput>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(PI.PlayCutscene)
       {
        PlayCutscene();
       }
    }
    void PlayCutscene()
    {
        EvilMC.gameObject.SetActive(false);
        PI.PlayCutscene = false;
        PI.canMove = false;
        anim.SetBool("PlayCutscene",true);
        anim.SetBool("PlayBackground",true);
        Debug.Log("Playing Cutscene");
        StartCoroutine(LoadGameWon(9f));
    }
     private IEnumerator LoadGameWon(float time)
    {
        yield return new WaitForSeconds(time);
        GameWonScreen.gameObject.SetActive(true);
    }

}
