using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour

{
    public static InventoryManager Instance;

    private int bronzeCount = 0; // Jumlah bronze dalam inventory

    public Canvas inventoryCanvas;
    public Text bronzeCountText;

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
        Debug.Log("Bronze added to inventory: " + amount + " Total: " + bronzeCount);

        if (isInventoryActive)
        {
            UpdateBronzeCountText();
        }
    }

    private void ToggleInventoryCanvas()
    {
        isInventoryActive = !isInventoryActive;
        inventoryCanvas.gameObject.SetActive(isInventoryActive);

        if (isInventoryActive)
        {
            UpdateBronzeCountText();
        }
    }

    private void UpdateBronzeCountText()
    {
        bronzeCountText.text = "Bronze: " + bronzeCount;
    }
}
