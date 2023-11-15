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
    private int currentHour = 0; 
    private int currentMinute = 0; 
    private int currentDay = 1;
    private string[] dayNames; 
    private string[] dailyDebts; 
    private float updateInterval = 0.5f; 
    private float timeSinceLastUpdate = 0f; 

    void Start()
    {
        
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
            "500", 
            "750", 
            "1000",  
            "1300", 
            "1600",  
            "1850", 
            "2500"   
        };

        UpdateDayAndDebtText(); 
    }

    void Update()
    {
        
        timeSinceLastUpdate += Time.deltaTime;

        if (timeSinceLastUpdate >= updateInterval)
        {
            UpdateTime();
            timeSinceLastUpdate = 0f; 
        }
    }

    void UpdateTime()
    {
        
        currentMinute++;

        if (currentMinute >= 60)
        {
            currentMinute = 0;
            currentHour++;

            if (currentHour >= 24)
            {
                currentHour = 0;
                currentDay++;

                
                if (currentDay > 7)
                {
                    currentDay = 1;
                }

                
                HandleDayChange(currentDay);
            }
        }

        
        timeText.text = currentHour.ToString("00") + ":" + currentMinute.ToString("00");
    }

    void HandleDayChange(int day)
    {

        Debug.Log("Hari berubah menjadi: " + dayNames[day - 1]);

      
        UpdateDayAndDebtText();
    }

    void UpdateDayAndDebtText()
    {
        
        dayText.text = "Hari: " + dayNames[currentDay - 1];
        debtText.text = "Hutang: " + dailyDebts[currentDay - 1] + "Gc";
    }
}
