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
    [SerializeField]
    private Text upgradeCostTextDamage;


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
        if (playerMovement.damagePerHit == 10f) // Upgrade dari level 1 ke level 2
        {
            if (GameManager.Instance.GetPlayerMoney() >= 150)
            {
                playerMovement.damagePerHit = 20f;
                GameManager.Instance.SubtractMoney(150);

                if (damageButton != null)
                {
                    damageButton.GetComponentInChildren<Text>().text = "Upgrade To level 3";
                }
                if (upgradeCostTextDamage != null)
                {
                    upgradeCostTextDamage.text = "Upgrade Cost: 200Gc"; 
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Drill ke lvl 2");
            }
        }
        else if (playerMovement.damagePerHit == 20f) // Upgrade dari level 2 ke level 3
        {
            if (GameManager.Instance.GetPlayerMoney() >= 200)
            {
                playerMovement.damagePerHit = 30f;
                GameManager.Instance.SubtractMoney(200);

                if (damageButton != null)
                {
                    damageButton.GetComponentInChildren<Text>().text = "Upgrade To level 4";
                }
                if (upgradeCostTextDamage != null)
                {
                    upgradeCostTextDamage.text = "Upgrade Cost: 300Gc"; 
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Drill ke level 3");
            }
        }
        // Tambahkan blok kode untuk upgrade ke level selanjutnya jika diperlukan
    }

}
    



