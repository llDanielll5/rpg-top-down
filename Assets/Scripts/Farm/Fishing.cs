using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    private PlayerItems playerItems;
    private PlayerAnim playerAnim;
    private Player player;
    private bool isFishing;

    [SerializeField]
    private int fishPercent;

    [SerializeField]
    private GameObject fishPrefab;
    public List<GameObject> randomPrefabs = new List<GameObject>();

    void Start()
    {
        playerItems = FindObjectOfType(typeof(PlayerItems)) as PlayerItems;
        player = FindObjectOfType(typeof(Player)) as Player;
        playerAnim = player.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        OnFishingCondition();
    }

    public void OnFishing()
    {
        int randomValue = UnityEngine.Random.Range(1, 100);
        if (randomValue <= fishPercent)
        {
            System.Random rnd = new System.Random();

            int randomPrefab = rnd.Next(0, 3);

            Instantiate(
                randomPrefabs[randomPrefab],
                player.transform.position + new Vector3(UnityEngine.Random.Range(-2f, -1f), 0, 0),
                quaternion.identity
            );

            // instancia um peixe
            // Instantiate(
            //     fishPrefab,
            //     player.transform.position + new Vector3(UnityEngine.Random.Range(-2f, -1f), 0, 0),
            //     quaternion.identity
            // );
        }
        else
        {
            // falhou
        }
    }

    public void OnFishingCondition()
    {
        if (isFishing && playerItems.Fishes <= playerItems.maxFishes && Input.GetKeyDown(KeyCode.F))
        {
            playerAnim.OnFishingStart();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isFishing = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isFishing = false;
    }
}
