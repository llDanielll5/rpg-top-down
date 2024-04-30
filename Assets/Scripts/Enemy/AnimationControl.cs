using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float attackRadius;

    [SerializeField]
    private LayerMask playerLayer;
    private PlayerAnim playerAnim;
    private Animator anim;
    private Skeleton skeleton;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerAnim = FindObjectOfType<PlayerAnim>();
        skeleton = GetComponentInParent<Skeleton>();
    }

    public void PlayAnimation(string animation)
    {
        if (!skeleton.isDead)
        {
            switch (animation)
            {
                case "idle":
                    anim.SetInteger("transition", 0);
                    break;
                case "walk":
                    anim.SetInteger("transition", 1);
                    break;
                case "attack":
                    anim.SetInteger("transition", 2);
                    break;
            }
        }
    }

    public void Attack()
    {
        Collider2D hit = Physics2D.OverlapCircle(attackPoint.position, attackRadius, playerLayer);
        if (hit != null)
        {
            playerAnim.OnHit();
        }
    }

    public void OnHit()
    {
        if (!skeleton.isDead)
        {
            if (skeleton.currentHealth <= 0f)
            {
                anim.SetTrigger("death");
                skeleton.isDead = true;
                Destroy(skeleton.gameObject, 1.2f);
            }
            else
            {
                skeleton.healthBar.fillAmount = skeleton.currentHealth / skeleton.totalHealth;
                anim.SetTrigger("hit");
                skeleton.currentHealth--;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
