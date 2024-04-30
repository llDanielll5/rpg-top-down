using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [Header("Stats")]
    public float currentHealth;
    public float totalHealth;
    public Image healthBar;
    public bool isDead;
    public float radiusAttack;

    [Header("Components")]
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private AnimationControl animControl;

    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private LayerMask playerLayer;

    [SerializeField]
    private GameObject skeletonPrefab;

    private Player player;
    private bool detectedPlayer;

    void Start()
    {
        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        currentHealth = totalHealth;
    }

    void Update()
    {
        if (!isDead && detectedPlayer)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
            UpdateAnimations();
            SpriteXPosition();
        }

        // InstantiateSkeletons();
    }

    void FixedUpdate()
    {
        DetectPlayer();
    }

    void UpdateAnimations()
    {
        if (
            Vector2.Distance(transform.position, player.transform.position)
            <= agent.stoppingDistance
        )
            animControl.PlayAnimation("attack");
        else
            animControl.PlayAnimation("walk");
    }

    void SpriteXPosition()
    {
        float enemyXPosition = player.transform.position.x - transform.position.x;

        if (enemyXPosition < 0)
            transform.eulerAngles = new Vector2(0, 180);
        else
            transform.eulerAngles = new Vector2(0, 0);
    }

    public void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radiusAttack, playerLayer);

        if (hit != null)
            detectedPlayer = true;
        else
        {
            detectedPlayer = false;
            animControl.PlayAnimation("idle");
            agent.isStopped = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radiusAttack);
    }

    // void InstantiateSkeletons()
    // {
    //     if (isDead)
    //     {
    //         for (int i = 0; i < 1; i++)
    //         {
    //             Instantiate(
    //                 skeletonPrefab,
    //                 transform.position
    //                     + new Vector3(
    //                         UnityEngine.Random.Range(-1f, 1f),
    //                         UnityEngine.Random.Range(-1f, 1f),
    //                         0f
    //                     ),
    //                 transform.rotation
    //             );
    //         }
    //         isDead = false;
    //     }
    // }
}
