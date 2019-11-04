using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Abdulkarem Alani #300993768
/// This is a switch scene controller when the player collides with the contaning object.
/// Assets were used from opengameart.
/// https://opengameart.org/content/2d-platform-ground-stone-tiles - Ground
///https://opengameart.org/content/krook-tree - Tree
///https://opengameart.org/content/simple-sky - Background
///https://opengameart.org/content/platformer-jumping-sounds -Jump sound
///https://opengameart.org/content/completion-sound -Coin Collect
///https://opengameart.org/content/animated-turtle -Turtle
/// </summary>

public class SwitchScne : MonoBehaviour
{
    [SerializeField] public string newLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(newLevel);
        }
    }
}
