using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
       public AudioSource coinCollect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        coinCollect.Play();
        Destroy(gameObject);
    
    }
}
