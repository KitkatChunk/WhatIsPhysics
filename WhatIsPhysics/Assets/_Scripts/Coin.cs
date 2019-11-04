using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abdulkarem Alani #300993768
/// This is a coin controller when the player collides the coin it get destroyed and plays a sound.
/// Assets were used from opengameart.
/// https://opengameart.org/content/2d-platform-ground-stone-tiles - Ground
///https://opengameart.org/content/krook-tree - Tree
///https://opengameart.org/content/simple-sky - Background
///https://opengameart.org/content/platformer-jumping-sounds -Jump sound
///https://opengameart.org/content/completion-sound -Coin Collect
///https://opengameart.org/content/animated-turtle -Turtle

/// </summary>
public class Coin : MonoBehaviour
{
       public AudioSource coinCollect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        coinCollect.Play();
        Destroy(gameObject);
    
    }
}
