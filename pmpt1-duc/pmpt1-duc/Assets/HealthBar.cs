using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public float maxHealth = 300f;
    public float currentHealth;

    public HealthBar healthBar;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Collider2D collision;
    
    void Start(){
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        collision = GetComponent<Collider2D>();
    }
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f); 
    }
    public void SetHealth(float health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
            Debug.Log("-20");
        }
        
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
