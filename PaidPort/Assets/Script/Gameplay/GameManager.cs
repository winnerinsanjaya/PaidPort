using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerMoney = 500;

    
    private static GameManager instance;
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

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }

    // Fungsi untuk menambahkan uang ke pemain.
    public void AddMoney(int amount)
    {
        playerMoney += amount;
        Debug.Log("Pemain memiliki sekarang: " + playerMoney + " uang.");
    }

    // Fungsi untuk menyimpan uang pemain (misalnya saat bermain ulang level).
    public void SaveMoney()
    {
        PlayerPrefs.SetInt("PlayerMoney", playerMoney);
        PlayerPrefs.Save();
        Debug.Log("Uang pemain telah disimpan.");
    }

    // Fungsi untuk load uang pemain saat permainan dimulai.
    public void LoadMoney()
    {
        if (PlayerPrefs.HasKey("PlayerMoney"))
        {
            playerMoney = PlayerPrefs.GetInt("PlayerMoney");
            Debug.Log("Uang pemain telah dimuat: " + playerMoney + " uang.");
        }
    }
   
    public void SubtractMoney(int amount)
    {
        playerMoney -= amount;
        Debug.Log("Pemain memiliki sekarang: " + playerMoney + " uang.");
    }
    public void UpdateMoney(int newAmount)
    {
        playerMoney = newAmount;
        Debug.Log("Jumlah uang pemain diperbarui: " + playerMoney + " uang.");
    }
    public int GetPlayerMoney()
    {
        return playerMoney;
    }
}

