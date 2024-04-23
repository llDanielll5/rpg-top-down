using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRender;
    [SerializeField] private SpriteRenderer progressSpriteRender;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private int digAmout; //quantidade de "escavação"
    private PlayerItems playerItems;


    [Header("Settings")]
    private int initialDigAmount;
    // [SerializeField] private enum SlotType { carrot };
    private bool isDigged;
    private bool isWatering;
    [SerializeField]private float currentWater;
    public float MaxWater { get => 25f; }

    [Header("ProgressImages")]
    [SerializeField] private GameObject progressGameObject;
    [SerializeField] private Sprite progress0;
    [SerializeField] private Sprite progress20;
    [SerializeField] private Sprite progress40;
    [SerializeField] private Sprite progress60;
    [SerializeField] private Sprite progress80;
    [SerializeField] private Sprite progress100;

    // SlotType slotType = new SlotType();

    void Start()
    {
        initialDigAmount = digAmout;
        playerItems = FindObjectOfType<PlayerItems>();
    }

    void Update()
    {
        if(isDigged) OnWatering();
    }

    public void OnHit()
    {
        digAmout --;
        if(digAmout == 0){
            spriteRender.sprite = hole;
            isDigged = true;
        }
    }

    void OnWatering()
    {
        float waterPercent = currentWater / MaxWater * 100;
        if(waterPercent >= 100f) currentWater = 25f;
        if(isWatering)
        {
            progressGameObject.SetActive(true);
            currentWater += 0.05f;
        }
        else 
        {
            progressGameObject.SetActive(false);
        }

        if(waterPercent < 20f)
        {
            progressSpriteRender.sprite = progress0;
        }
        else if(waterPercent > 20f && waterPercent <= 40f)
        {
            progressSpriteRender.sprite = progress20;
        }
        else if(waterPercent > 40f && waterPercent <= 60f)
        {
            progressSpriteRender.sprite = progress40;
        }
        else if (waterPercent > 60f && waterPercent <= 80f)
        {
            progressSpriteRender.sprite = progress60;
        }
        else if(waterPercent > 80f && waterPercent < 100f)
        {
            progressSpriteRender.sprite = progress80;
        }
        else if(waterPercent >= 100f)
        {
            progressSpriteRender.sprite = progress100;
            spriteRender.sprite = carrot;

            if(Input.GetKeyDown(KeyCode.E) && playerItems.Carrots < playerItems.maxCarrot)
            {
                spriteRender.sprite = hole;
                playerItems.Carrots++;
                currentWater = 0f;
            }
        }
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Shovel") && !isDigged) OnHit();
        if(collision.CompareTag("WaterCan")) isWatering = true;
        // if(collision.CompareTag("Shovel") && isDigged && digAmout == 0) Debug.Log("Já cavou!"); criar animação de quando não pode mais cavar
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("WaterCan")) isWatering = false;
    }
}
