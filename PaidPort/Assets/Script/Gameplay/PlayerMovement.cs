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

    [SerializeField]
    private Collider2D playerCollider;
    [SerializeField]
    private float damagePerHit = 10f;
    [SerializeField]
    private float pullSpeed = 2.0f;
    private float lastDamageTime = 0f;
    private Transform pullTarget = null;

    private Transform playerTransform;
    [SerializeField]
    private LayerMask groundLayer;

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
        //Memanggil fungsi DestroyGround
        DestroyGround();
        
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
    void DestroyGround()
    {
        // Periksa jika ada tanah di depan pemain
        Vector2 playerPosition = playerCollider.bounds.center;

        if (Input.GetKey(KeyCode.DownArrow))
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
            MoveAndDamage(Vector2.right);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveAndDamage(Vector2.left);
        }

        
        if (pullTarget != null)
        {
            Vector3 targetPosition = pullTarget.position;
            playerCollider.transform.position = Vector3.MoveTowards(playerCollider.transform.position, targetPosition, pullSpeed * Time.deltaTime);

            // Menghentikan menarik apabila sudah ada di tengah ground
            if (playerCollider.bounds.Intersects(pullTarget.GetComponent<Collider2D>().bounds))
            {
                pullTarget = null;
            }
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

            // Menarik pemain ke tengah ground yang diberi damage
            pullTarget = groundCollider.transform;
        }
    }

    void MoveAndDamage(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(playerCollider.bounds.center, direction, playerCollider.bounds.extents.x + 0.1f, groundLayer);

        if (hit.collider != null && Time.time - lastDamageTime >= 1f)
        {
            DamageGround(hit.collider);
        }
    }
}
    







