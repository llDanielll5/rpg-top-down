﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    public DialogueSettings dialogue;

    bool playerHit;

    private List<string> sentences = new List<string>();
    private List<string> actorName = new List<string>();
    private List<Sprite> actorSprite = new List<Sprite>();


    void Start()
    {
        GetNPCInfo();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& playerHit)
        {
            if (DialogueControl.instance.IsShowing == true)
            {
                DialogueControl.instance.NextSentence();
                return;
            }
            DialogueControl.instance.Speech(sentences.ToArray(), actorName.ToArray(), actorSprite.ToArray());
        }   
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
            DialogueControl.instance.ResetSentence();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }

    void GetNPCInfo()
    {
        for(int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.instance.language)
            {
                case DialogueControl.idiom.Portugues:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;

                case DialogueControl.idiom.English:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;

                case DialogueControl.idiom.Spanish:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            }

            actorName.Add(dialogue.dialogues[i].actorName);
            actorSprite.Add(dialogue.dialogues[i].profile);
        }
    }
}
