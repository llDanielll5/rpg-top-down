using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField]
    private AudioClip bgmMusic;
    private AudioController audioC;

    void Start()
    {
        audioC = FindObjectOfType<AudioController>();
        audioC.PlayBGM(bgmMusic);
    }
}
