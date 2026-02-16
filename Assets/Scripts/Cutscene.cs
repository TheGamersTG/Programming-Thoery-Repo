using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{


    //Character Sprites
        public List<Sprite> daveSprites;
        public List<Sprite> tartraSprites;

    
        private List<Sprite> currSprites;

        public GameObject Speaker;
        public TextMeshProUGUI dialogue;

        public Dialogue dialogueManager;

        public List<String> currDialogue;


//Audio
        public AudioSource mainAudio;

        public AudioClip level1Music;
        public AudioClip level2Music;

        int dia;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dia = 0;
        //int level = game or main manager.getLevel()
        //int character = game or main manager.getCharacter()
    
        int level = MainManager.instance.level;

        if (level == 1)
        {
            currSprites = daveSprites;
        }
        else {
            currSprites = tartraSprites; 
        }
       
        Speaker.GetComponent<SpriteRenderer>().sprite = currSprites[0];
        setAudio(level);
        mainAudio.Play();
    

        currDialogue = dialogueManager.getDialogue(level);
        
        dialogue.text = currDialogue[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))     {
                dia += 1;
                if (dia == currDialogue.Count()){
                SceneManager.LoadScene(1);
                }
            else
            {
             dialogue.text = currDialogue[dia];
             Speaker.GetComponent<SpriteRenderer>().sprite = currSprites[1];
            }
            }
        }
    

    void setAudio(int level)
    {
        if (level == 1)
        {
            mainAudio.clip = level1Music;
        }
        else if (level == 2)
        {
            mainAudio.clip = level2Music;
        }
    }
}
