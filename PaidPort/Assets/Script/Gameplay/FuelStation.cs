using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelStation : MonoBehaviour
{
    public GameObject FuelCanvas;

    public GameObject FuelScreen;
    [SerializeField]
    private GameObject GameScreen;

    private bool inArea;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FuelCanvas.SetActive(true);
           inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FuelCanvas.SetActive(false);
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
                FuelScreen.SetActive(true);
                GameScreen.SetActive(false);
            }
        }
    }
    public void Exit()
    {
        Time.timeScale = 1;
        FuelScreen.SetActive(false);
        GameScreen.SetActive(true);
    }

    public void Button()
    {
        Debug.Log("Fuel Bertambah"); 
    }
}
