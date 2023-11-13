using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour

{
    public int maxHealth = 100;
    public int currentHealth;

    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        // Contoh: Kurangi health setiap kali pemain diserang atau terkena sesuatu
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(20); // Contoh: Serangan mengurangi 20 health
        }
    }

    void TakeDamage(int damage)
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

    void UpdateHealthBar()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBar.fillAmount = healthPercentage;
    }
}



