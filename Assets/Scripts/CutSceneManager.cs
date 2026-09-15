using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    PlayerInput PI;
    Animator anim;
    public GameObject EvilMC;
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
        Debug.Log("Playing Cutscene");
    }

}
