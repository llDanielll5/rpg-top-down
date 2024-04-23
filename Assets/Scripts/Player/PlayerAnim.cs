using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private Fishing fishing;

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
    }


    #region Movement

    void OnRun()
    {
        if (player.IsRunning)
        {
            anim.SetInteger("transition", 2);
        }
        
    }
    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)//sqrMagnitude, pega o vector 2 e retorna o valor total do vector 2.                                    // Retorna a média do X e do Y;
        {
            if (player.IsRolling)
            {
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

        if(player.IsDigging)
        {
            anim.SetInteger("transition", 4);
        }

        if(player.IsGetWater || player.IsWatering)
        {
            anim.SetInteger("transition", 5);
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
}
