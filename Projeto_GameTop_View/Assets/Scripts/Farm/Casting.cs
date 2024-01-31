using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{


    [SerializeField] private int percentage; //Chance de pegar um peixe
    [SerializeField] private GameObject fishePrefab;


    private PlayerItems player;
    private PlayerAnimation playerAnim;
    private bool detectingPlayer;

    void Start()
    {
        player = FindObjectOfType<PlayerItems>();
        playerAnim = player.GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.OnCastingStarted();
        }
    }

    public void OnCasting()
    {
        int randomValue = Random.Range(1,100);
        if(randomValue <= percentage)
        {
            //Pescou
            Instantiate(fishePrefab,player.transform.position + new Vector3(Random.Range(-2f,-1f),0f,0f),Quaternion.identity);
            Debug.Log("Pescou");

        }
        else
        {
            //Não pescou 
            Debug.Log("Não Pescou");
        }
    }

    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            detectingPlayer = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectingPlayer = false;
        }
    }
}
