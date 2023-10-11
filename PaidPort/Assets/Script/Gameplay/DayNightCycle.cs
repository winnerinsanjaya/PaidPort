using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dayText;
    [SerializeField]
    private TextMeshProUGUI debtText;
    [SerializeField]
    private TextMeshProUGUI timeText;
    private int currentHour = 0; // Jam saat ini (0-23)
    private int currentMinute = 0; // Menit saat ini (0-59)
    private int currentDay = 1; // Hari saat ini
    private string[] dayNames; // Array yang berisi nama hari
    private string[] dailyDebts; // Array yang berisi hutang harian 
    private float updateInterval = -1.0f; // Interval waktu untuk pembaruan jam (setiap detik)
    private float timeSinceLastUpdate = 0f; // Waktu sejak pembaruan jam terakhir

    void Start()
    {
        // Inisialisasi array nama hari dan array hutang harian sesuai dengan kebutuhan Anda
        dayNames = new string[]
        {
            "Senin",
            "Selasa",
            "Rabu",
            "Kamis",
            "Jumat",
            "Sabtu",
            "Minggu"
        };

        dailyDebts = new string[]
        {
            "500",  // Hari 1
            "750",  // Hari 2
            "1000",  // Hari 3
            "1300",  // Hari 4
            "1600",  // Hari 5
            "1850",  // Hari 6
            "2500"   // Hari 7
        };

        UpdateDayAndDebtText(); // Memperbarui teks hari dan hutang pada UI
    }

    void Update()
    {
        // Update waktu saat ini
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= updateInterval)
        {
            UpdateTime(); // Pembaruan jam
            timeSinceLastUpdate = 0f; // Reset waktu terakhir pembaruan
        }
    }

    void UpdateTime()
    {
        // Update jam dan menit saat ini
        currentMinute++;

        if (currentMinute >= 60)
        {
            currentMinute = 0;
            currentHour++;

            if (currentHour >= 24)
            {
                currentHour = 0;
                currentDay++;

                // Jika sudah mencapai hari ke-8, kembali ke hari ke-1
                if (currentDay > 7)
                {
                    currentDay = 1;
                }

                // Panggil metode untuk mengatur perubahan hari
                HandleDayChange(currentDay);
            }
        }

        // Memperbarui teks waktu pada UI
        timeText.text = currentHour.ToString("00") + ":" + currentMinute.ToString("00");
    }

    void HandleDayChange(int day)
    {

        Debug.Log("Hari berubah menjadi: " + dayNames[day - 1]);

        // Memperbarui teks hari dan hutang pada UI
        UpdateDayAndDebtText();
    }

    void UpdateDayAndDebtText()
    {
        // Update teks objek TextMeshPro dengan nama hari dan hutang harian saat ini
        dayText.text = "Hari: " + dayNames[currentDay - 1];
        debtText.text = "Hutang: " + dailyDebts[currentDay - 1] + "Gc";
    }
}
