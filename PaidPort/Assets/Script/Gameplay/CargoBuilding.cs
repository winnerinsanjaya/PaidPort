using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBuilding : MonoBehaviour
{

    [SerializeField]
    private GameObject CargoCanvas;
    [SerializeField]
    private GameObject CargoScreen;
    [SerializeField]
    private GameObject GameScreen;


    private bool inArea;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CargoCanvas.SetActive(true);
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CargoCanvas.SetActive(false);
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
                CargoScreen.SetActive(true);
                GameScreen.SetActive(false);
            }
        }
    }
    public void Exit()
    {
        Time.timeScale = 1;
        CargoScreen.SetActive(false);
        GameScreen.SetActive(true);
    }
    public void SellAll()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SellAllItems();
        }
        else
        {
            Debug.LogError("InventoryManager Instance is null.");
        }
    }
}