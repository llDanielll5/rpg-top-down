using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idioma
    {
        Portugues,
        English,
        Spanish
    }

    public idioma language;

    [Header("Components")]
    public GameObject dialogueObj;//janela do dialogo
    public Image profileSprite;//sprite do perfil
    public Text speechText;//texto da fala
    public Text actorNameText;//nome do npc

    [Header("Settings")]
    public float typingSpeed;//velocidade de exibição da fala

    //variáveis de controle
    private bool isShowing;//se a janela está visível
    private int index; //index das sentenças/falas/textos

    public bool IsShowing { get => isShowing; set => isShowing = value; }

    private string[] sentences;

    public static DialogueControl instance;//transformando em um singleton, estático.

    //chamado antes do Start().
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pular para a proxima frase/fala
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else// quando se terminam os textos
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    //chamar a fala do npc
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
