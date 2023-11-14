using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

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

    [SerializeField]
    private Collider2D playerCollider;
    [SerializeField]
    private float damagePerHit = 10f;
    [SerializeField]
    private float lastDamageTime = 0f;
    private Vector2 moveDirection;
    private SpriteRenderer spriteRenderer;



    private Transform playerTransform;
    [SerializeField]
    private LayerMask groundLayer;
   


    Vector2 movement;

    void Start()
    {
        ////Set gravitasi dari awal langsung ada
        rb.gravityScale = gravityDown;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        DestroyGround();
    
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Movement();
        HandleMovement();
        HandleGravity();
       
    }
    private void Movement()
    {
        //Memangil fungsi input gerakan Horizontal & Vertical di keyboard
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(x, 0);

        if (moveDirection.magnitude == 0)
        {
            // Anda dapat mengatur nilai default di sini jika Anda ingin pemain berhenti sepenuhnya
            moveDirection = Vector2.zero;
            // Atau Anda dapat mempertahankan arah pergerakan sebelumnya
        }

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
        if (isFacingRight)
        {
            spriteRenderer.flipX = false; // Tidak flip
        }
        else
        {
            spriteRenderer.flipX = true; // Melakukan flip pada sumbu X
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
    void DestroyGround()
    {
        // Periksa jika ada tanah di depan pemain
        Vector2 playerPosition = playerCollider.bounds.center;
        bool isGrounded = IsGrounded();

        if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
        {
            // Periksa jika ada tanah di bawah pemain
            RaycastHit2D hit = Physics2D.Raycast(playerPosition, Vector2.down, playerCollider.bounds.extents.y * 2, groundLayer);

            if (hit.collider != null)
            {
                DamageGround(hit.collider);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveAndDamage(Vector2.right, isGrounded);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveAndDamage(Vector2.left, isGrounded);
        }
       
      
    }

    void DamageGround(Collider2D groundCollider)
    {
        // Memeriksa apakah objek yang dihancurkan memiliki komponen "GroundHealth" 
        GroundHealth groundHealth = groundCollider.GetComponent<GroundHealth>();

        if (groundHealth != null && Time.time - lastDamageTime >= 1f)
        {
            // Hancurkan ground dengan jumlah damage yang telah ditentukan
            groundHealth.TakeDamage(damagePerHit);
            lastDamageTime = Time.time;
        }
    }

    void MoveAndDamage(Vector2 direction, bool IsGrounded)
    {


        if (IsGrounded && Time.time - lastDamageTime >= 1f)
        {
            RaycastHit2D hit = Physics2D.Raycast(playerCollider.bounds.center, direction, playerCollider.bounds.extents.x + 0.1f, groundLayer);

            if (hit.collider != null)
            {
                DamageGround(hit.collider);
            }

            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                lastDamageTime = Time.time;
            }
            playerCollider.transform.Translate(movement * Time.deltaTime);
        }

    }
    bool IsGrounded()
    {
        // Pemeriksaan apakah pemain menapak di atas ground
        RaycastHit2D hit = Physics2D.Raycast(playerCollider.bounds.center, Vector2.down, playerCollider.bounds.extents.y + 0.1f, groundLayer);
        return hit.collider != null;
    }

}
    







