using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private Fishing fishing;
    private bool isHiting;
    private float timeCount;
    private float recoveryTime = 1f;

    [Header("Attack Settings")]
    [SerializeField]
    private Transform playerAttackPoint;

    [SerializeField]
    private float playerAttackRadius;

    [SerializeField]
    private LayerMask enemyLayer;

    private void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        fishing = FindObjectOfType<Fishing>();
    }

    private void Update()
    {
        OnMove();
        OnRun();
        PlayerRecovery();
    }

    #region Movement

    #region Attack
    public void OnAttack()
    {
        Collider2D hit = Physics2D.OverlapCircle(
            playerAttackPoint.position,
            playerAttackRadius,
            enemyLayer
        );
        if (hit != null)
        {
            hit.GetComponentInChildren<AnimationControl>().OnHit();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(playerAttackPoint.position, playerAttackRadius);
    }

    #endregion

    void OnRun()
    {
        if (player.IsRunning && player.direction.sqrMagnitude > 0)
        {
            anim.SetInteger("transition", 2);
        }
    }

    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0) //sqrMagnitude, pega o vector 2 e retorna o valor total do vector 2.                                    // Retorna a média do X e do Y;
        {
            if (player.IsRolling)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("roll"))
                    anim.SetTrigger("isRoll");
            }
            else
            {
                anim.SetInteger("transition", 1);
            }
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (player.IsCutting)
        {
            anim.SetInteger("transition", 3);
        }

        if (player.IsDigging)
        {
            anim.SetInteger("transition", 4);
        }

        if (player.IsGetWater || player.IsWatering)
        {
            anim.SetInteger("transition", 5);
        }

        if (player.IsAttacking)
        {
            anim.SetInteger("transition", 6);
        }
    }

    #endregion

    //é chamado quando o jogador pressiona o botão de ação!
    public void OnFishingStart()
    {
        anim.SetTrigger("isFishing");
        player.isPaused = true;
    }

    //é chamado quando termina de executar a animação de pesca
    public void OnFishingEnd()
    {
        fishing.OnFishing();
        player.isPaused = false;
    }

    public void OnHammeringStart()
    {
        anim.SetBool("hammering", true);
    }

    public void OnHammeringEnd()
    {
        anim.SetBool("hammering", false);
    }

    public void OnHit()
    {
        if (!isHiting)
        {
            player.GetComponent<PlayerStats>().DecreaseLife(1f);
            anim.SetTrigger("hit");
            isHiting = true;
        }
    }

    public void PlayerRecovery()
    {
        if (isHiting)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= recoveryTime)
            {
                isHiting = false;
                timeCount = 0f;
            }
        }
    }
}
