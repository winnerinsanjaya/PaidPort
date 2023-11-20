using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance;
    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    private int maxLimit = 10;
    private int totalItems = 0;
    private int money = 100;

    public Canvas inventoryCanvas;
    public Text bronzeCountText;
    public Text silverCountText;
    public Text goldCountText;
    public Text diamondCountText;
    public Text MoneyText;

    private bool isInventoryActive = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        inventoryCanvas.gameObject.SetActive(false);

        inventory.Add("Bronze", 0);
        inventory.Add("Silver", 0);
        inventory.Add("Gold", 0);
        inventory.Add("Diamond", 0);
    }

    private void Start()
    {
        LoadMoney();
        UpdateMoneyText();
        UpdateItemCountText("Bronze");
        UpdateItemCountText("Silver");
        UpdateItemCountText("Gold");
        UpdateItemCountText("Diamond");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryCanvas();
        }

        if (inventoryCanvas.gameObject.activeSelf && !Input.GetKey(KeyCode.I) && Input.anyKeyDown)
        {
            inventoryCanvas.gameObject.SetActive(false);
        }
    }

    public void AddItem(string item, int amount)
    {
        if (inventory.ContainsKey(item))
        {
            int newTotal = totalItems + amount;
            if (newTotal <= maxLimit) 
            {
                if (inventory[item] + amount >= 0)
                {
                    totalItems = newTotal;
                    inventory[item] += amount;

                    Debug.Log(item + " added to inventory: " + amount);

                    if (isInventoryActive)
                    {
                        UpdateItemCountText(item);
                    }
                }
                else
                {
                    Debug.Log("Invalid operation: Cannot have negative items in inventory.");
                }
            }
            else
            {
                Debug.Log("Inventory full. Cannot add more items.");
            }
        }
        else
        {
            Debug.Log("Item " + item + " does not exist in inventory.");
        }
    }

    public void SellAllItems()
    {
        int totalValue = 0;
        List<string> itemsToSell = new List<string>(inventory.Keys);
        foreach (var item in itemsToSell)
        {
            totalValue += inventory[item] * GetValueOfItem(item);
            inventory[item] = 0; 
        }

        money += totalValue;
        SaveMoney(money);
        UpdateMoneyText();
        Debug.Log("Sold all items for: " + totalValue + " money.");
    }
    private int GetValueOfItem(string item)
    {
        switch (item)
        {
            case "Bronze":
                return 150;
            case "Silver":
                return 300;
            case "Gold":
                return 500;
            case "Diamond":
                return 1000;
            default:
                return 0;
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
        SaveMoney(money);
        UpdateMoneyText();

        Debug.Log("Pemain memiliki sekarang: " + money + " uang.");
    }

    public void SubtractMoney(int amount)
    {
        money -= amount;
        SaveMoney(money);
        UpdateMoneyText();

        Debug.Log("Pemain memiliki sekarang: " + money + " uang.");
    }

    public void SaveMoney(int amount)
    {
        PlayerPrefs.SetInt("money", amount);
    }

    public void LoadMoney()
    {
        if (PlayerPrefs.HasKey("money"))
        {
            int amount = PlayerPrefs.GetInt("money");
            money = amount;
            UpdateMoneyText();
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

    private void ToggleInventoryCanvas()
    {
        isInventoryActive = !isInventoryActive;
        inventoryCanvas.gameObject.SetActive(isInventoryActive);

        if (isInventoryActive)
        {
            UpdateItemCountText("Bronze");
            UpdateItemCountText("Silver");
            UpdateItemCountText("Gold");
            UpdateItemCountText("Diamond");
        }
    }

    private void UpdateItemCountText(string item)
    {
        switch (item)
        {
            case "Bronze":
                bronzeCountText.text = "Bronze x " + inventory[item];
                break;
            case "Silver":
                silverCountText.text = "Silver x " + inventory[item];
                break;
            case "Gold":
                goldCountText.text = "Gold x " + inventory[item];
                break;
            case "Diamond":
                diamondCountText.text = "Diamond x " + inventory[item];
                break;
            default:
                break;
        }
      
    }
}


