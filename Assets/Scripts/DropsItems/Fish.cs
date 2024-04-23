using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerItems playerItems = collision.GetComponent<PlayerItems>();

        if(collision.CompareTag("Player") && playerItems.Fishes < playerItems.maxFishes)
        {
            playerItems.Fishes++;
            Destroy(gameObject);
        }
    }
}
