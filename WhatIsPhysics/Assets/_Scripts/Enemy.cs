using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  
    public float speed;
    public SpriteRenderer spriteRend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Move();
        CheckBounds();

       
    }

    public void Move()
    {
        Vector2 newPosition = new Vector2(speed, 0.0f);
        Vector2 currentPosition = transform.position;
        currentPosition += newPosition;
        transform.position = currentPosition;

        if (transform.position.x >= 12 && transform.position.x <= 12.5)
        {
            spriteRend.flipX = true;
        }
        if (transform.position.x <= -24.8 && transform.position.x >= -25)
        {
            spriteRend.flipX = false;
        }
    }
    void CheckBounds()
    {
        if (transform.position.x >= 12.5f || transform.position.x <= -25f)
        {
            speed = -speed;
        }
    }

    
}