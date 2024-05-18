using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private float life;
    private float maxLife = 3f;

    public float Life
    {
        get => life;
        set => life = value;
    }
    public float MaxLife
    {
        get => maxLife;
        set => maxLife = value;
    }

    void Awake()
    {
        life = maxLife;
    }

    public void DecreaseLife(float damage)
    {
        life -= damage;

        if (life <= 0f)
        {
            Debug.Log("You Die!");
            Time.timeScale = 0;
        }
    }
}
