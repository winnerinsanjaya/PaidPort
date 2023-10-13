using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float gravity = 30f;

    Vector2 movement;

    void Update()
    {
        //Memanggil fungsi Movement
        Movement();

       
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        ApplyGravity();
    }
    private void Movement()
    {
        //Memangil fungsi input gerakan Horizontal & Vertical di keyboard
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2 (x, 0);

        //Mendeklarasi untuk membalik player
        if (x < 0)
        {
            Facing(false);
        }
        if (x > 0)
        {
            Facing(true);
        }
    }

    private void Facing(bool isFacingRight)
    {
        //Fungsi untuk membalik player
        if (isFacingRight == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
            return;
        }
        if (isFacingRight == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }

    }
    private void ApplyGravity()
    {
        //Fungsi Gravitasi
        Vector2 gravityVector = Vector2.down * gravity;
        rb.AddForce(gravityVector);
    }
    
    
}
