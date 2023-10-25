using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProseduralMap : MonoBehaviour
{
    public Transform groundPrefab;

    public Transform bronzePrefab;

    public Transform silverPrefab;

    public Transform goldPrefab;

    public Transform diamondPrefab;

    public Transform groundCollider;
    [SerializeField]
    private Vector2 spawnPosition = new Vector2(0, 0);
    [SerializeField]
    private int groundWidth = 10;
    [SerializeField]
    private int groundHeight = 10;
    [SerializeField]
    private float bronzeChance = 0.05f;
    [SerializeField]
    private float silverChance = 0.03f;
    [SerializeField]
    private float goldChance = 0.02f;
    [SerializeField]
    private float diamondChance = 0.01f;
    [SerializeField]
    private int maxDepth = 50;

    private int currentDepth = 0;

    void Start()
    {
        // Membuat lantai awal
        GenerateInitialGround();
    }

    void Update()
    {
        // Cek jika kita perlu membuat lebih banyak lantai ke bawah
        if (Camera.main.transform.position.y > spawnPosition.y - (groundHeight * groundCollider.localScale.y) && currentDepth < maxDepth)
        {
            GenerateGround();
        }
    }

  void GenerateInitialGround()
    {
        for (int i = 0; i < groundWidth; i++)
        {
            for (int j = 0; j < groundHeight; j++)
            {
                Vector3 spawnPos = new Vector3(spawnPosition.x + i * groundCollider.localScale.x, spawnPosition.y - j * groundCollider.localScale.y, 0);
                float randomValue = Random.value;
                int currentLayerDepth = -currentDepth;

                if (currentLayerDepth >= -2)
                {
                    Instantiate(groundPrefab, spawnPos, Quaternion.identity);
                }
            }
        }
        currentDepth += groundHeight;
    }

    void GenerateGround()
    {
        for (int i = 0; i < groundWidth; i++)
        {
            Vector3 spawnPos = new Vector3(spawnPosition.x + i * groundCollider.localScale.x, spawnPosition.y - (groundHeight * groundCollider.localScale.y), 0);
            float randomValue = Random.value;
            int currentLayerDepth = -currentDepth;

            if (currentLayerDepth >= -2)
            {
                Instantiate(groundPrefab, spawnPos, Quaternion.identity);
            }
            else if (currentLayerDepth >= -150)
            {
                if (randomValue <= bronzeChance)
                {
                    Instantiate(bronzePrefab, spawnPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(groundPrefab, spawnPos, Quaternion.identity);
                }
            }
            else if (currentLayerDepth >= -300)
            {
                if (randomValue <= silverChance)
                {
                     Instantiate(silverPrefab, spawnPos, Quaternion.identity);
                }
                else
                {
                    Transform ground = Instantiate(groundPrefab, spawnPos, Quaternion.identity);
                    GroundHealth groundHealth = ground.GetComponent<GroundHealth>();
                    if (groundHealth != null)
                    {
                        groundHealth.maxHealth = 40;
                    }
                }
            }
            else if (currentLayerDepth >= -400)
            {
                if (randomValue <= goldChance)
                {
                  Instantiate(goldPrefab, spawnPos, Quaternion.identity);  
                }
                else
                {
                    Transform ground = Instantiate(groundPrefab, spawnPos, Quaternion.identity);
                    GroundHealth groundHealth = ground.GetComponent<GroundHealth>();
                    if (groundHealth != null)
                    {
                        groundHealth.maxHealth = 60;
                    }
                }
            }
            else
            {
                if (randomValue <= diamondChance)
                {
                    Instantiate(diamondPrefab, spawnPos, Quaternion.identity);
                }

                else
                {
                    Transform ground = Instantiate(groundPrefab, spawnPos, Quaternion.identity);
                    GroundHealth groundHealth = ground.GetComponent<GroundHealth>();
                    if (groundHealth != null)
                    {
                        groundHealth.maxHealth = 80;
                    }
                }
            }
        }
        spawnPosition.y -= groundCollider.localScale.y;
        currentDepth += groundHeight;
    }
}