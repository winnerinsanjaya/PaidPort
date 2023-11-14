using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BronzeItem : MonoBehaviour
{
    public int bronzeCount = 1; // Jumlah bronze yang ditambahkan ke inventory per hancur

    private void OnDestroy()
    {
        Collider2D playerCollider = GetPlayerCollider();

        if (playerCollider != null && playerCollider.CompareTag("Player"))
        {
            // Tambahkan bronze ke inventory
            InventoryManager.Instance.AddBronze(bronzeCount);
        }
    }

    private Collider2D GetPlayerCollider()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f); // Sesuaikan dengan ukuran collider yang sesuai

        foreach (Collider2D collider in colliders)
        {
            // Cek apakah collider adalah pemain
            if (collider.CompareTag("Player"))
            {
                return collider;
            }
        }

        return null;
    }
}
