using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour

{
    public static InventoryManager Instance;

    private int bronzeCount = 0; 
    private int silverCount = 0;
    private int goldCount = 0;
    private int diamondCount = 0;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryCanvas();
        }

        // Menutup Inventory Canvas jika sedang aktif dan pemain menekan tombol apa pun
        if (inventoryCanvas.gameObject.activeSelf && !Input.GetKey(KeyCode.I) && Input.anyKeyDown)
        {
            inventoryCanvas.gameObject.SetActive(false);
        }
    }

    public void AddBronze(int amount)
    {
        bronzeCount += amount;
        Debug.Log("Bronze added to inventory: " + amount );

        if (isInventoryActive)
        {
            UpdateBronzeCountText();
        }
    }
    public void AddSilver(int amount)
    {
        silverCount += amount;
        Debug.Log("Silver added to inventory: " + amount );

        if (isInventoryActive)
        {
            UpdateSilverCountText();
        }
    }
    public void AddGold(int amount)
    {
        goldCount += amount;
        Debug.Log("Gold added to inventory: " + amount);

        if (isInventoryActive)
        {
            UpdateGoldCountText();
        }
    }
    public void AddDiamond(int amount)
    {
        diamondCount += amount;
        Debug.Log("Diamond added to inventory: " + amount);

        if (isInventoryActive)
        {
            UpdateDiamondCountText();
        }
    }

    private void ToggleInventoryCanvas()
    {
        isInventoryActive = !isInventoryActive;
        inventoryCanvas.gameObject.SetActive(isInventoryActive);

        if (isInventoryActive)
        {
            UpdateBronzeCountText();
            UpdateSilverCountText();
            UpdateGoldCountText();
            UpdateDiamondCountText();
        }
    }

    private void UpdateBronzeCountText()
    {
        bronzeCountText.text = "Bronze: " + bronzeCount;
    }

    private void UpdateSilverCountText()
    {
        silverCountText.text = "Silver: " + silverCount;
    }
    private void UpdateGoldCountText()
    {
        goldCountText.text = "Gold: " + goldCount;
    }
    private void UpdateDiamondCountText()
    {
        diamondCountText.text = "Diamond: " + diamondCount;
    }
}
