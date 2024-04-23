using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int totalWood; 
    [SerializeField] private float waterAmount;
    [SerializeField] private int carrots;
    [SerializeField] private int fishes;

    public int TotalWood { get => totalWood; set => totalWood = value; }
    public float WaterAmount {get => waterAmount; set => waterAmount = value;}
    public int Carrots {get => carrots; set => carrots = value;}
    public int Fishes {get => fishes; set => fishes = value;}

    readonly public float maxWater = 50f;
    readonly public int maxWood = 64;
    readonly public int maxCarrot = 64;
    readonly public int maxFishes = 64;

    void Update()
    {
        if(waterAmount < 0) waterAmount = 0;
    }

    public bool UseWood(int woodValue)
    {
        if(totalWood >= woodValue)
        {
            totalWood -= woodValue;
            return true;
        }
        else return false;
    }
}
