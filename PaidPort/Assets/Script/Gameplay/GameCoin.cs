using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCoin : MonoBehaviour

{
    public Text moneyText;

    private void Start()
    {
        // Memuat jumlah uang pemain saat permainan dimulai.
        GameManager.Instance.LoadMoney();
        UpdateMoneyUI();
    }

    // Fungsi untuk menambahkan uang ke pemain.
    public void AddMoney(int amount)
    {
        GameManager.Instance.AddMoney(amount);
        UpdateMoneyUI();
    }

    // Fungsi untuk mengurangi uang pemain (jika diperlukan).
    public void SubtractMoney(int amount)
    {
        GameManager.Instance.AddMoney(-amount);
        UpdateMoneyUI();
    }

    // Fungsi untuk memperbarui UI jumlah uang pemain.
    private void UpdateMoneyUI()
    {
        moneyText.text = ""  + GameManager.Instance.GetPlayerMoney().ToString() + "Gc";
    }

    // Fungsi untuk menyimpan uang pemain saat permainan berakhir atau berpindah level.
    private void OnDestroy()
    {
        GameManager.Instance.SaveMoney();
    }
}

