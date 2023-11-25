using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour

{
    public int totalFuel = 100;
    public int currentFuel;

    public float damageInterval = 2f; // Interval waktu antara damage
    private float nextDamageTime;

    public Image fuelBarImage;

    void Start()
    {
        currentFuel = totalFuel;
        UpdateFuelBar();
    }

    void Update()
    {
        // Tes fungsi damage setiap beberapa detik
        if (Time.time >= nextDamageTime)
        {
            TakeDamage(5); // Ganti dengan jumlah damage yang diinginkan
            nextDamageTime = Time.time + damageInterval;
        }
    }

    void TakeDamage(int damage)
    {
        currentFuel -= damage;
        UpdateFuelBar();

        // Cek jika player mati
        if (currentFuel <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implementasi kematian player, misalnya memanggil fungsi respawn
        // atau menampilkan layar game over
        Debug.Log("Player Mati");
        // Tambahkan kode kematian di sini sesuai kebutuhan game Anda
    }

    public void UpdateFuelBar()
    {
        float fillAmount = (float)currentFuel / totalFuel;
        fuelBarImage.fillAmount = fillAmount;
    }
    public void ResetHealth()
    {
        currentFuel = totalFuel;
        UpdateFuelBar();
        Debug.Log("Health direset ke nilai awal: " + currentFuel);
        // Tambahkan logika lain yang diperlukan setelah reset health
    }

}


