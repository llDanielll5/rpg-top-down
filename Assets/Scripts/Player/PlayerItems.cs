using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField]
    private int totalWood;

    [SerializeField]
    private float waterAmount;

    [SerializeField]
    private int carrots;

    [SerializeField]
    private int fishes;

    [SerializeField]
    private int badItems;

    public int TotalWood
    {
        get => totalWood;
        set => totalWood = value;
    }
    public float WaterAmount
    {
        get => waterAmount;
        set => waterAmount = value;
    }
    public int Carrots
    {
        get => carrots;
        set => carrots = value;
    }
    public int Fishes
    {
        get => fishes;
        set => fishes = value;
    }
    public int BadItems
    {
        get => badItems;
        set => badItems = value;
    }

    public readonly float maxWater = 50f;
    public readonly int maxWood = 64;
    public readonly int maxCarrot = 64;
    public readonly int maxFishes = 64;

    void Update()
    {
        if (waterAmount < 0)
            waterAmount = 0;
    }

    public bool UseWood(int woodValue)
    {
        if (totalWood >= woodValue)
        {
            totalWood -= woodValue;
            return true;
        }
        else
            return false;
    }
}
