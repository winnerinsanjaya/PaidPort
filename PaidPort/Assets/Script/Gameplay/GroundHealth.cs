using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class GroundHealth : MonoBehaviour
{
    public float maxHealth = 20f;
    [SerializeField]
    private float healDelay = 1.5f;
    private float currentHealth;
    private float lastDamageTime;

    private void Start()
    {
        currentHealth = maxHealth;
        lastDamageTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - lastDamageTime >= healDelay)
        {
            // Pemulihan kesehatan jika sudah cukup waktu
            currentHealth = Mathf.Min(currentHealth + (Time.deltaTime / healDelay) * maxHealth, maxHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        // Kurangi hp ground berdasarkan jumlah kerusakan yang diberikan
        currentHealth -= damage;
        lastDamageTime = Time.time;

        // Cek jika hp ground sudah habis
        if (currentHealth <= 0)
        {
            // Hancurkan ground
            Destroy(gameObject);
        }
    }
}

