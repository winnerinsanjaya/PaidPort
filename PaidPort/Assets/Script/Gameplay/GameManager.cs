using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text MoneyText;
    private int money = 100;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        UpdateMoneyText();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();

        Debug.Log("Pemain memiliki sekarang: " + money + " uang.");

    }
    public void SubtractMoney(int amount)
    {
        money -= amount;

        UpdateMoneyText();

        Debug.Log("Pemain memiliki sekarang: " + money + " uang.");


    }
    public void SaveMoney()
    {
        PlayerPrefs.SetInt("PlayerMoney", money);
        PlayerPrefs.Save();
        Debug.Log("Uang pemain telah disimpan.");
    }
    public void LoadMoney()
    {
        if (PlayerPrefs.HasKey("PlayerMoney"))
        {
            money = PlayerPrefs.GetInt("PlayerMoney");
            Debug.Log("Uang pemain telah dimuat: " + money + " uang.");
        }
    }
    public void UpdateMoneyText()
    {
        MoneyText.text = money + "Gc";
    }
    public int GetPlayerMoney()
    {
        return money;
    }
}


