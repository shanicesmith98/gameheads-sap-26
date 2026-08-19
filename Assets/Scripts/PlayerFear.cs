using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerFear : MonoBehaviour //GameManager (I'm scared to rename the script)
{
    public bool DarkLevel = true;
    public float maxFear = 100f;
    public float currentFear;
    float currentOpacity;
    


    public Slider FearSlider;
    public Image VisHealth;
    GameManager GM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GM = FindFirstObjectByType<GameManager>();
        currentFear = 0;
        UpdateFearUI();

        currentOpacity = currentFear/maxFear;
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
        Color currentOpacity = new Color(0f,0f,0f,currentFear/maxFear);
        VisHealth.color = currentOpacity;
    }


    void Update()
    {
        if(currentFear == maxFear)
        {
            GM.GameOver();
        }
    }
}









  



