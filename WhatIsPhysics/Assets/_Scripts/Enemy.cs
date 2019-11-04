using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Abdulkarem Alani #300993768
/// Enemy controller moves the player from a position to another, also flips X when the player gets to the end of the path.
/// Assets were used from opengameart.
/// https://opengameart.org/content/2d-platform-ground-stone-tiles - Ground
///https://opengameart.org/content/krook-tree - Tree
///https://opengameart.org/content/simple-sky - Background
///https://opengameart.org/content/platformer-jumping-sounds -Jump sound
///https://opengameart.org/content/completion-sound -Coin Collect
///https://opengameart.org/content/animated-turtle -Turtle
/// </summary>
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

        //Checking the direction of the player and fliping the x axis to change it accordingly.
        if (transform.position.x >= 12 && transform.position.x <= 12.5)
        {
            spriteRend.flipX = true;
        }
        if (transform.position.x <= -24.8 && transform.position.x >= -25)
        {
            spriteRend.flipX = false;
        }
    }
    //When Enemy gets to the end of the path the speed becomes negative to go from right to left.
    void CheckBounds()
    {
        if (transform.position.x >= 12.5f || transform.position.x <= -25f)
        {
            speed = -speed;
        }
    }

    
}