using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerFear : MonoBehaviour
{
    public bool DarkLevel = true;
    public float maxFear = 100f;
    public float currentFear;

    public Slider FearSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            //HealthSlider.value = maxHealth - (float)currentHealth;
            FearSlider.value = currentFear / maxFear;
        }
    }

    void Update()
    {
    }
}
