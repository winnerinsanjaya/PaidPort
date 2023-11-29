using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour

{
    public int totalFuel = 100;
    public int currentFuel;

    public float damageInterval = 2f; 
    private float nextDamageTime;

    public Image fuelBarImage;

    void Start()
    {
        currentFuel = totalFuel;
        UpdateFuelBar();
    }

    void Update()
    {
       
        if (Time.time >= nextDamageTime)
        {
            TakeDamage(5);
            nextDamageTime = Time.time + damageInterval;
        }
    }

    void TakeDamage(int damage)
    {
        currentFuel -= damage;
        UpdateFuelBar();

       
        if (currentFuel <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.GameOver();
        Debug.Log("Player Mati");
       
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
        
    }

}


