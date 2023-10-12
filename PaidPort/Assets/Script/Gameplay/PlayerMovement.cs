using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private Rigidbody2D rb;
    Vector2 movement;
    

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    private void Movement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2 (x, 0);

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
}
