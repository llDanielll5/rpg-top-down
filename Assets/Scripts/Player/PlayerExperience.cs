using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    [SerializeField]
    private int currentExp;

    [SerializeField]
    private int currentLevel;
    private int maxLevel = 99;
    public List<int> maxExperiences = new List<int>();
    public int GetLevel
    {
        get => currentLevel;
    }
    public int IncrementExperience
    {
        set => currentExp += value;
    }

    void Awake()
    {
        currentLevel = 1;
    }

    void Update()
    {
        if (currentExp >= maxExperiences[currentLevel - 1])
        {
            if (currentLevel == maxLevel)
                return;
            currentLevel++;
        }
    }
}
