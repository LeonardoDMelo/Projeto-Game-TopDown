using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa,
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj;  //Janela Dialogo
    public Image profileSprite;     //Sprite Perfil
    public Text speechText;         //Nome NPC
    public Text actorNameText;      // Velocidade Fala


    [Header("Settings")]
    public float typingSpeed;

    //Variaveis de controle
    public bool isShowing; //Se janela está visivel 
    private int index;      //index das sentenças 
    private string[] sentences;


    public static DialogueControl instance;

    //Chamado antes de todos os Start() na hieraquia de execução 
    private void Awake()
    {
        instance = this; 
    }
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    //Proxima frase
    public void NextSentence()
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1) 
            {
                index++;
                speechText.text =  "";
                StartCoroutine(TypeSentence());
            }
            else //Quando acabam os textos
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }
    //Chamar fala do NPC
    public void Speech(string[] txt)
    {
        if(!isShowing) 
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
