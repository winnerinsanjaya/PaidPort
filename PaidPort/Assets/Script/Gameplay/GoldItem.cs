using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldItem : MonoBehaviour
{
    public int goldCount = 1;

    private void OnDestroy()
    {
        Collider2D playerCollider = GetPlayerCollider();

        if (playerCollider != null && playerCollider.CompareTag("Player"))
        {

            InventoryManager.Instance.AddGold(goldCount);
        }
    }

    private Collider2D GetPlayerCollider()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);

        foreach (Collider2D collider in colliders)
        {

            if (collider.CompareTag("Player"))
            {
                return collider;
            }
        }

        return null;
    }
}
