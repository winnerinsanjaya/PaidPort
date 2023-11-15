using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour

{
    public static InventoryManager Instance;

    private Dictionary<string, int> inventory = new Dictionary<string, int>(); // Dictionary untuk menyimpan bahan
    private int maxLimit = 10; // Batas maksimal untuk keseluruhan bahan dalam inventaris
    private int totalItems = 0; // Jumlah total dari semua bahan dalam inventaris

    public Canvas inventoryCanvas;
    public Text bronzeCountText;
    public Text silverCountText;
    public Text goldCountText;
    public Text diamondCountText;

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

        // Tambahkan item-item awal ke dalam dictionary dengan nilai 0
        inventory.Add("Bronze", 0);
        inventory.Add("Silver", 0);
        inventory.Add("Gold", 0);
        inventory.Add("Diamond", 0);
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
            if (newTotal <= maxLimit) // Periksa apakah penambahan tidak melampaui batas maksimal
            {
                if (inventory[item] + amount >= 0) // Pastikan tidak ada bahan yang bernilai negatif
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
                bronzeCountText.text = "Bronze: " + inventory[item];
                break;
            case "Silver":
                silverCountText.text = "Silver: " + inventory[item];
                break;
            case "Gold":
                goldCountText.text = "Gold: " + inventory[item];
                break;
            case "Diamond":
                diamondCountText.text = "Diamond: " + inventory[item];
                break;
            default:
                break;
        }
    }
}


