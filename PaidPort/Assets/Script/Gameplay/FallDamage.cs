using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{ 
    public float fallDamageMultiplier = 1.5f;
    public float minFallDamageHeight = 5f;

    private Vector2 lastPosition;
    private bool isGrounded = false;

    private void Start()
    {
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        CheckFallDamage();
        lastPosition = transform.position;
    }

    private void CheckFallDamage()
    {
        Vector2 currentPosition = transform.position;
        float fallDistance = lastPosition.y - currentPosition.y;

        if (fallDistance > minFallDamageHeight && isGrounded)
        {
            float damage = fallDistance * fallDamageMultiplier;
            // Lakukan sesuatu dengan nilai damage, seperti mengurangi kesehatan pemain
            Debug.Log("Player took fall damage: " + damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

