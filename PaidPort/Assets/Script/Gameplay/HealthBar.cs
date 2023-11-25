using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour

{
    public float maxHealth = 10;
    public float currentHealth;

    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Memastikan health tidak kurang dari 0 atau lebih dari maxHealth
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implementasi aksi ketika pemain mati, misalnya mengubah scene atau menampilkan pesan kalah
        Debug.Log("Player mati");
        // Misalnya: UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        Debug.Log("Health direset ke nilai awal: " + currentHealth);
        // Tambahkan logika lain yang diperlukan setelah reset health
    }

    public void UpdateHealthBar()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBar.fillAmount = healthPercentage;
    }
  
}



