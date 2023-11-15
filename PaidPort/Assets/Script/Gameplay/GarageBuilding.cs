using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageBuilding : MonoBehaviour
{
    [SerializeField]
    private GameObject GarageCanvas;
   

    private bool inArea;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GarageCanvas.SetActive(true);
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GarageCanvas.SetActive(false);
            inArea = false;
        }
    }
}
