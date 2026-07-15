using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerFear : MonoBehaviour //GameManager (I'm scared to rename the script)
{

    public int levelsCompleted;
    public bool AutoDeplete = true;
    public float maxFear = 100f;
    public float currentFear;
    public bool TouchingLight;


    public Slider FearSlider;

    private GameManager GM;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentFear = 0;
        UpdateFearUI();
        GM = FindFirstObjectByType<GameManager>();

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

    void Update()
    {
        if(currentFear == maxFear)
        {
            GM.GameOver();
        }

        if(AutoDeplete)
        {
            if(TouchingLight)
            {
            TakeDamage(-5 * Time.deltaTime);
            }
            else
            {
            TakeDamage(5 * Time.deltaTime);
            }
        }
    }
}









  



