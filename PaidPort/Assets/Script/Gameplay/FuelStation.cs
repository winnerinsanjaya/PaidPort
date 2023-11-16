using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelStation : MonoBehaviour
{
    [SerializeField]
    private GameObject FuelCanvas;
    [SerializeField]
    private GameObject FuelScreen;
    [SerializeField]
    private GameObject GameScreen;
    public FuelBar fuelBar;

    private bool inArea;
    int itemCost = 50;



    void Start()
    {
        // Mendapatkan komponen PlayerHealth dari objek dengan skrip PlayerHealth
        fuelBar = GameObject.FindObjectOfType<FuelBar>();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FuelCanvas.SetActive(true);
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FuelCanvas.SetActive(false);
            inArea = false;
        }
    }
    private void Update()
    {
        if (inArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0;
                FuelScreen.SetActive(true);
                GameScreen.SetActive(false);
            }
        }
    }
    public void Exit()
    {
        Time.timeScale = 1;
        FuelScreen.SetActive(false);
        GameScreen.SetActive(true);
    }

    public void Button()
    {
        if (GameManager.Instance.GetPlayerMoney() >= itemCost)
        {
            // Jika pemain memiliki cukup uang, kurangi uang pemain sesuai dengan harga item.
            GameManager.Instance.SubtractMoney(itemCost);
            fuelBar.ResetHealth();
            Debug.Log("Fuel bertambah");
           
        }
        else
        {
            
            Debug.Log("Uang tidak cukup");
        }
    }
}

