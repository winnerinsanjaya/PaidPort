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
        // Kurangi kesehatan tanah berdasarkan jumlah kerusakan yang diberikan
        currentHealth -= damage;

        // Cek jika kesehatan tanah sudah habis
        if (currentHealth <= 0)
        {
            // Hancurkan tanah atau lakukan tindakan lain sesuai kebutuhan Anda
            Destroy(gameObject);
        }
    }
}

