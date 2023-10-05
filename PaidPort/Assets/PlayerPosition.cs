using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI positionText;
    [SerializeField]
    private Transform playerTransform; // Referensi transformasi pemain

    private float lastYPosition; // Menyimpan posisi Y terakhir pemain

    // Start is called before the first frame update
    void Start()
    {
        lastYPosition = playerTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        PosisionPlayer();
    }
    private void PosisionPlayer()
    {
        if (positionText != null && playerTransform != null)
        {
            float playerY = playerTransform.position.y;

            if (playerY != lastYPosition)
            {

                positionText.text = Mathf.RoundToInt(playerY) + "Ft";
                lastYPosition = playerY;
            }
        }
    }
}
