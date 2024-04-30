using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private PlayerItems playerItems;
    private Player player;
    public bool isWaterRange;

    void Start()
    {
        playerItems = GameObject.FindObjectOfType(typeof(PlayerItems)) as PlayerItems;
        player = FindObjectOfType(typeof(Player)) as Player;
    }

    void Update()
    {
        OnGetWater();
    }

    public void OnGetWater()
    {
        if (player.IsGetWater && isWaterRange && playerItems.WaterAmount <= playerItems.maxWater)
        {
            playerItems.WaterAmount += 0.05f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCan"))
            isWaterRange = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterCan"))
            isWaterRange = false;
    }
}
