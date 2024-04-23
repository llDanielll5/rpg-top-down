using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float timeCount;
    private PlayerItems playerItems;


    void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }

    
    void Update()
    {
        timeCount += Time.deltaTime;

        if(timeCount < timeMove){
            transform.Translate(speed * Time.deltaTime * Vector2.right);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && playerItems.TotalWood < playerItems.maxWood)
        {
            collision.GetComponent<PlayerItems>().TotalWood++;
            Destroy(gameObject);
        }
    }
}
