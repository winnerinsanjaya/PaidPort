using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBuilding : MonoBehaviour
{

    [SerializeField]
    private GameObject CargoCanvas;
    

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
}
