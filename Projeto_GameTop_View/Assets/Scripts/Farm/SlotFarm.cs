using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;


    [Header("Settings")]
    [SerializeField] private int digAmount;
    [SerializeField] private float waterAmount; //Total de agua para nascer planta
    [SerializeField] private bool detecting;



    private int initialDigAmount;
    private float currentWater;
    private bool dugHole;

    PlayerItems playerItems;

    private void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        initialDigAmount = digAmount;
    }

     private void Update()
    {
        if(dugHole)
        {
            if(detecting)
            {
                currentWater += 0.01f;
            }
            //Chegou na quantidade necessaria 
            if(currentWater >= waterAmount) 
            {
                spriteRenderer.sprite = carrot;

                if(Input.GetKeyDown(KeyCode.E))
                {
                    spriteRenderer.sprite = hole;
                    playerItems.carrots++;
                    currentWater = 0f;
                }
            }

        }
    }

    public void OnHit()
    {
        digAmount--;

        if(digAmount <= initialDigAmount /2 )
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }

        /*
        if(digAmount <= 0)
        {
            //Plantar cenoura
            spriteRenderer.sprite = carrot;
        }
        */
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.CompareTag("Dig"))
        {
            OnHit();
        }
        if(collision.CompareTag("Water"))
        {
            detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        detecting = false;
    }
}
