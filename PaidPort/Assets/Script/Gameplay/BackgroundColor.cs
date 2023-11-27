using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour

{
    public Transform player;
    public Color brownColor = new Color(0.6f, 0.3f, 0.1f, 1f);

    private Camera backgroundCamera;
    private Color originalColor;

    void Start()
    {
        
        backgroundCamera = GetComponent<Camera>();

        
        originalColor = backgroundCamera.backgroundColor;
    }

    void Update()
    {
       
        if (player.position.y <= 3f)
        {
           
            ChangeBackgroundColor(brownColor);
        }
        else
        {
            
            ChangeBackgroundColor(originalColor);
        }
    }

    
    void ChangeBackgroundColor(Color color)
    {
        backgroundCamera.backgroundColor = color;
    }
}


