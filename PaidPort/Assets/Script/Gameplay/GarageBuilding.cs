using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarageBuilding : MonoBehaviour
{
    [SerializeField]
    private GameObject GarageCanvas;
    [SerializeField]
    private GameObject GarageScreen;
    [SerializeField]
    private GameObject GameScreen;
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private Button damageButton;


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
    private void Update()
    {
        if (inArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0;
                GarageScreen.SetActive(true);
                GameScreen.SetActive(false);
            }
        }
    }
    public void Exit()
    {
        Time.timeScale = 1;
        GarageScreen.SetActive(false);
        GameScreen.SetActive(true);
    }
    public void UpdateDamage()
    {
        if (GameManager.Instance.GetPlayerMoney() >= 150)
        {

            playerMovement.damagePerHit = 20f;
            GameManager.Instance.SubtractMoney(150);


            if (playerMovement.damagePerHit == 20f)
            {
                if (damageButton != null)
                {
                    damageButton.GetComponentInChildren<Text>().text = "Upgrade To level 3";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Drill ke lvl 2");
            }
        }


        else if (playerMovement.damagePerHit == 20f)
        {

            if (GameManager.Instance.GetPlayerMoney() >= 200)
            {
                playerMovement.damagePerHit = 30f;

                GameManager.Instance.SubtractMoney(200);
            }

            if (playerMovement.damagePerHit == 30f)
            {
                if (damageButton != null)
                {
                    damageButton.GetComponentInChildren<Text>().text = "Upgrade To level 4";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Drill ke level 3");
            }
        }
    }
}


