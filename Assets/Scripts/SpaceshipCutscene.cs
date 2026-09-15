using UnityEngine;

public class SpaceshipCutscene : MonoBehaviour
{
    Animator anim;
    ManagerScene MS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    anim = GetComponent<Animator>();
    MS = FindFirstObjectByType<ManagerScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MS.Play)
        {
            imsotiredbruh();
        }
    }

    void imsotiredbruh()
    {
        MS.Play = false;
        anim.SetBool("Start",true);
    }
}
