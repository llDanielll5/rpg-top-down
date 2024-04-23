using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Color startColor;
    [SerializeField] private Color buildingColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmount;
    [SerializeField] private Transform point;
    [SerializeField] private GameObject houseCollider;
    private bool playerDetect;
    private Player player;
    private PlayerAnim playerAnim;
    private PlayerItems playerItems;
    private float timeCount;
    private bool isBuilding;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    void Update()
    {
        
        if(playerDetect && Input.GetKeyDown(KeyCode.F) && playerItems.UseWood(3))
        {
            isBuilding = true;
            playerAnim.OnHammeringStart();
            houseSprite.color = buildingColor;
            player.transform.position = point.position;
            player.isPaused = true;
        }

        if(isBuilding)
        {
            timeCount += Time.deltaTime;
            if(timeCount > timeAmount)
            {
                playerAnim.OnHammeringEnd();
                houseSprite.color = endColor;
                player.isPaused = false;
                houseCollider.SetActive(true);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player")) playerDetect = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player")) playerDetect = false;
    }
}
