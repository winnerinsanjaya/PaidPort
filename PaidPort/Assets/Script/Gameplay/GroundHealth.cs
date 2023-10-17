using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHealth : MonoBehaviour
{
    public float maxHealth = 20f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Kurangi hp ground berdasarkan jumlah kerusakan yang diberikan
        currentHealth -= damage;

        // Cek jika hp ground sudah habis
        if (currentHealth <= 0)
        {
            // Hancurkan ground
            Destroy(gameObject);
        }
    }
}

