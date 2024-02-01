using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform point;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmount;



    [SerializeField] private bool detectingPlayer;
    private PlayerItems player;
    private PlayerAnimation playerAnim;

    private float timeCount;
    private bool isBegining;

    void Start()
    {
        player = FindObjectOfType<PlayerItems>(); 
        playerAnim = FindObjectOfType<PlayerAnimation>();
       
    }

    void Update()
    {
        if(detectingPlayer && Input.GetKeyDown(KeyCode.E)) 
        {
            
            isBegining = true;
            playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = point.position;


        }
        if (isBegining)
        {
            timeCount += Time.deltaTime;

            if(timeCount >= timeAmount) 
            {
            //Casa finalizada
            playerAnim.OnHammeringEnded();
            houseSprite.color = endColor;
                isBegining = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
