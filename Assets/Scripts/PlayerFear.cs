using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerFear : MonoBehaviour //GameManager (I'm scared to rename the script)
{
    public bool DarkLevel = true;
    public float maxFear = 100f;
    public float currentFear;



    public Slider FearSlider;
    GameManager GM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GM = FindFirstObjectByType<GameManager>();

        currentFear = 0;
        UpdateFearUI();
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
    }
}









  



