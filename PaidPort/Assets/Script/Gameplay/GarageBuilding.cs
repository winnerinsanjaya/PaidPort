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
    private GameObject ServiceScreen;
    [SerializeField]
    private GameObject UpgradeScreen;
    //damage upgrade
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private Button damageButton;
    [SerializeField]
    private Text upgradeCostTextDamage;
    //health upgrade
    [SerializeField]
    private HealthBar healthBar;
    [SerializeField]
    private Button healthButton;
    [SerializeField]
    private Text upgradeCostTextHealth;
    //inventory upgrade
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Button inventoryButton;
    [SerializeField]
    private Text upgradeCostTextInventory;
    //fuel upgrade
    [SerializeField]
    private FuelBar fuelBar;
    [SerializeField]
    private Button fuelButton;
    [SerializeField]
    private Text upgradeCostTextFuel;

    private bool isGarageScreenActive = false;
    private bool isServiceScreenActive = true;
    private bool isUpgradeScreenActive = false;



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
                ServiceScreen.SetActive(true);
                GameScreen.SetActive(false);
                isGarageScreenActive = true;
            }
        }
        if (isGarageScreenActive && Input.GetKeyDown(KeyCode.Tab))
        {
            if (isServiceScreenActive)
            {
                ServiceScreen.SetActive(false);
                UpgradeScreen.SetActive(true);
                isServiceScreenActive = false;
                isUpgradeScreenActive = true;
            }
            else if (isUpgradeScreenActive)
            {
                ServiceScreen.SetActive(true);
                UpgradeScreen.SetActive(false);
                isServiceScreenActive = true;
                isUpgradeScreenActive = false;
            }
        }

    }
    public void Exit()
    {
        Time.timeScale = 1;
        GarageScreen.SetActive(false);
        GameScreen.SetActive(true);
    }
    public void ServiceButton()
    {
        if (GameManager.Instance.GetPlayerMoney() >= 500)
        {

            GameManager.Instance.SubtractMoney(500);
            healthBar.ResetHealth();
            Debug.Log("Fuel bertambah");

        }
        else
        {

            Debug.Log("Uang tidak cukup");
        }
    }
    public void UpdateDamage()
    {
        if (playerMovement.damagePerHit == 10f) // Upgrade dari level 1 ke level 2
        {
            if (GameManager.Instance.GetPlayerMoney() >= 750)
            {
                playerMovement.damagePerHit = 20f;
                GameManager.Instance.SubtractMoney(750);

                if (damageButton != null)
                {
                    damageButton.GetComponentInChildren<Text>().text = "Upgrade To level 3";
                }
                if (upgradeCostTextDamage != null)
                {
                    upgradeCostTextDamage.text = "Upgrade Cost: 2000Gc";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Drill ke lvl 2");
            }
        }
        else if (playerMovement.damagePerHit == 20f) // Upgrade dari level 2 ke level 3
        {
            if (GameManager.Instance.GetPlayerMoney() >= 2000)
            {
                playerMovement.damagePerHit = 30f;
                GameManager.Instance.SubtractMoney(2000);

                if (damageButton != null)
                {
                    damageButton.GetComponentInChildren<Text>().text = "Upgrade To level 4";
                }
                if (upgradeCostTextDamage != null)
                {
                    upgradeCostTextDamage.text = "Upgrade Cost: 5000Gc";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Drill ke level 3");
            }
        }
        else if (playerMovement.damagePerHit == 30f) // Upgrade dari level 3 ke level 4
        {
            if (GameManager.Instance.GetPlayerMoney() >= 5000)
            {
                playerMovement.damagePerHit = 40f;
                GameManager.Instance.SubtractMoney(5000);

                if (damageButton != null)
                {
                    damageButton.GetComponentInChildren<Text>().text = "Max";
                }
                if (upgradeCostTextDamage != null)
                {
                    upgradeCostTextDamage.text = "Max";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Drill ke level 4");
            }
        }
    }

    public void UpdateHealth()
    {
        if (healthBar.maxHealth == 10) // Upgrade dari level 1 ke level 2
        {
            if (GameManager.Instance.GetPlayerMoney() >= 750)
            {
                healthBar.maxHealth = 20;
                healthBar.currentHealth = 20;
                healthBar.UpdateHealthBar();
                GameManager.Instance.SubtractMoney(750);

                if (healthButton != null)
                {
                    healthButton.GetComponentInChildren<Text>().text = "Upgrade To level 3";
                }
                if (upgradeCostTextHealth != null)
                {
                    upgradeCostTextHealth.text = "Upgrade Cost: 2000Gc";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Body ke lvl 2");
            }
        }
        else if (healthBar.maxHealth == 20) // Upgrade dari level 2 ke level 3
        {
            if (GameManager.Instance.GetPlayerMoney() >= 2000)
            {
                healthBar.maxHealth = 30;
                healthBar.currentHealth = 30;
                healthBar.UpdateHealthBar();
                GameManager.Instance.SubtractMoney(2000);

                if (healthButton != null)
                {
                    healthButton.GetComponentInChildren<Text>().text = "Upgrade To level 4";
                }
                if (upgradeCostTextHealth != null)
                {
                    upgradeCostTextHealth.text = "Upgrade Cost: 5000Gc";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Bodoy ke level 3");
            }
        }
        else if (healthBar.maxHealth == 30) // Upgrade dari level 3 ke level 4
        {
            if (GameManager.Instance.GetPlayerMoney() >= 5000)
            {
                healthBar.maxHealth = 40;
                healthBar.currentHealth = 40;
                healthBar.UpdateHealthBar();
                GameManager.Instance.SubtractMoney(5000);

                if (healthButton != null)
                {
                    healthButton.GetComponentInChildren<Text>().text = "Max";
                }
                if (upgradeCostTextHealth != null)
                {
                    upgradeCostTextHealth.text = "Max";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Drill ke level 4");
            }
        }
    }
    public void UpdateInventory()
    {
        if (gameManager.maxLimit == 10) // Upgrade dari level 1 ke level 2
        {
            if (GameManager.Instance.GetPlayerMoney() >= 750)
            {
                gameManager.maxLimit = 20;
                GameManager.Instance.SubtractMoney(750);

                if (inventoryButton != null)
                {
                    inventoryButton.GetComponentInChildren<Text>().text = "Upgrade To level 3";
                }
                if (upgradeCostTextInventory != null)
                {
                    upgradeCostTextInventory.text = "Upgrade Cost: 2000Gc";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Inventory ke lvl 2");
            }
        }
        else if (gameManager.maxLimit == 20) // Upgrade dari level 2 ke level 3
        {
            if (GameManager.Instance.GetPlayerMoney() >= 2000)
            {
                gameManager.maxLimit = 30;
                GameManager.Instance.SubtractMoney(2000);

                if (inventoryButton != null)
                {
                    inventoryButton.GetComponentInChildren<Text>().text = "Upgrade To level 4";
                }
                if (upgradeCostTextInventory != null)
                {
                    upgradeCostTextInventory.text = "Upgrade Cost: 5000Gc";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Inventory ke level 3");
            }
        }
        else if (gameManager.maxLimit == 30) // Upgrade dari level 3 ke level 4
        {
            if (GameManager.Instance.GetPlayerMoney() >= 5000)
            {
                gameManager.maxLimit = 40;
                GameManager.Instance.SubtractMoney(5000);

                if (inventoryButton != null)
                {
                    inventoryButton.GetComponentInChildren<Text>().text = "Max";
                }
                if (upgradeCostTextInventory != null)
                {
                    upgradeCostTextInventory.text = "Max";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Inventory ke level 4");
            }
        }
    }
    public void UpdateFuel()
    {
        if (fuelBar.totalFuel == 100) // Upgrade dari level 1 ke level 2
        {
            if (GameManager.Instance.GetPlayerMoney() >= 750)
            {
                fuelBar.totalFuel = 150;
                fuelBar.currentFuel = 150;
                fuelBar.UpdateFuelBar();
                GameManager.Instance.SubtractMoney(750);

                if (fuelButton != null)
                {
                    fuelButton.GetComponentInChildren<Text>().text = "Upgrade To level 3";
                }
                if (upgradeCostTextFuel != null)
                {
                    upgradeCostTextFuel.text = "Upgrade Cost: 2000Gc";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Fuel Tank ke lvl 2");
            }
        }
        else if (fuelBar.totalFuel == 150) // Upgrade dari level 2 ke level 3
        {
            if (GameManager.Instance.GetPlayerMoney() >= 2000)
            {
                fuelBar.totalFuel = 200;
                fuelBar.currentFuel = 200;
                fuelBar.UpdateFuelBar();
                GameManager.Instance.SubtractMoney(2000);

                if (fuelButton != null)
                {
                    fuelButton.GetComponentInChildren<Text>().text = "Upgrade To level 4";
                }
                if (upgradeCostTextFuel != null)
                {
                    upgradeCostTextFuel.text = "Upgrade Cost: 5000Gc";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Fuel Tank ke level 3");
            }
        }
        else if (fuelBar.totalFuel == 200) // Upgrade dari level 3 ke level 4
        {
            if (GameManager.Instance.GetPlayerMoney() >= 5000)
            {
                fuelBar.totalFuel = 300;
                fuelBar.currentFuel = 300;
                fuelBar.UpdateFuelBar();
                GameManager.Instance.SubtractMoney(5000);

                if (fuelButton != null)
                {
                    fuelButton.GetComponentInChildren<Text>().text = "Max";
                }
                if (upgradeCostTextFuel != null)
                {
                    upgradeCostTextFuel.text = "Max";
                }
            }
            else
            {
                Debug.Log("Uang tidak cukup untuk upgrade Drill ke level 4");
            }
        }
    }
}


    



