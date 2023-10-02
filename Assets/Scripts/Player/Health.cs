using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    float maxHealth = 100;
    private float currentHealth;
    [SerializeField] Image healthBar;
    int amount = 2;

    
    void Start()
    {
        MobPatrol.DoDamageEvent += takeDamage; 
        currentHealth = maxHealth;
    }

    void takeDamage()
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            healthBar.fillAmount = Mathf.Lerp(currentHealth, 0, 3f * Time.deltaTime);
        }
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / maxHealth, 3f * Time.deltaTime);
        ColorChanging();
    }

    void ColorChanging()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (currentHealth / maxHealth));
        healthBar.color = healthColor;
    }

    
}
