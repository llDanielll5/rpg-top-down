using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.CrashReportHandler;

public class Tree : MonoBehaviour
{

    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private ParticleSystem leafs;

    private bool isCut = false;
    public void OnHit()
    {
        anim.SetTrigger("isHit");
        leafs.Play();
        treeHealth--;
    
        if(treeHealth == 0){
            System.Random rnd = new System.Random();
            int woodCounts = rnd.Next(1, 5);
            for (int i = 0; i < woodCounts; i++)
            {
                Instantiate(woodPrefab, transform.position + new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0f), transform.rotation);
            }

            anim.SetTrigger("cut");
            isCut = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Axe") && !isCut) OnHit();
    }
}
