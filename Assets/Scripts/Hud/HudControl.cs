using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudControl : MonoBehaviour
{

    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Text woodUICount;
    [SerializeField] private Text carrotUICount;
    [SerializeField] private Text fishUICount;

    [Header("Tools")]
    // [SerializeField] private Image axeUI;
    // [SerializeField] private Image shovelUI;
    // [SerializeField] private Image waterCanUI;
    [SerializeField] private List<Image> toolsUI = new List<Image>();
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color unselectedColor;


    private PlayerItems playerItems;
    private Player player;

    void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = playerItems.GetComponent<Player>();
    }


    void Start()
    {
        waterUIBar.fillAmount = 0;
        woodUICount.text = "0";
        carrotUICount.text = "0";
        fishUICount.text = "0";

        for (int i = 0; i < toolsUI.Count; i++)
        {
            toolsUI[i].color = unselectedColor;
        }
    }

    void Update()
    {
        waterUIBar.fillAmount = playerItems.WaterAmount / playerItems.maxWater;
        woodUICount.text = playerItems.TotalWood.ToString();
        carrotUICount.text = playerItems.Carrots.ToString();
        fishUICount.text = playerItems.Fishes.ToString();

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if(i != 0)
            {
                if(i == player.handlingObj)
                {
                    toolsUI[i].color = selectedColor;
                }
                else 
                {
                    toolsUI[i].color = unselectedColor;
                }
            }
        }
    }
    
}
