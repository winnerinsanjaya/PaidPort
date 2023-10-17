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
    private float fallSpeed = 10f;
    [SerializeField]
    private float gravityDown = 20f;
    [SerializeField]
    private float gravityUp = 5f;

   
    Vector2 movement;

    void Start()
    {
        ////Set gravitasi dari awal langsung ada
        rb.gravityScale = gravityDown;
        
    }
    void Update()
    {
        //Memanggil fungsi Movement
        Movement();
        //Memanggil fungsi HanldeGravity
        HandleGravity();
        //Memanggil fungsi HandleMovement
        HandleMovement();
        
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
    private void Movement()
    {
        //Memangil fungsi input gerakan Horizontal & Vertical di keyboard
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(x, 0);

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
    void HandleGravity()
    {
        float currentGravity = movement.y > 0 ? gravityUp : gravityDown;
        rb.gravityScale = currentGravity;
    }
    void HandleMovement()
    {
        rb.velocity = new Vector2(movement.x * fallSpeed, rb.velocity.y);
    }

}





