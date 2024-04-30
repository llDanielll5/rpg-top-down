using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadItems : MonoBehaviour
{
    [SerializeField]
    private AudioClip getItemSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerItems playerItems = collision.GetComponent<PlayerItems>();

        if (collision.CompareTag("Player"))
        {
            playerItems.BadItems++;
            collision.GetComponent<ActorSFX>().PlaySFX(getItemSound);
            Destroy(gameObject);
        }
    }
}
