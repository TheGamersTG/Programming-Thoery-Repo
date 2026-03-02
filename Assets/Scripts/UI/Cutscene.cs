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

    
    //Player

    public GameObject opila;
    public GameObject tartra;
    //Character Sprites
        public List<Sprite> daveSprites;
        public List<Sprite> tartraSprites;
    
        private List<Sprite> currSprites;

        public GameObject Speaker;
        public TextMeshProUGUI dialogue;

        public Dialogue dialogueManager;

        public List<DialogueString> currDialogue;


//Audio
        public AudioSource mainAudio;

        public AudioClip level1Music;
        public AudioClip level2Music;
        
        //Sounds

        private List<AudioClip> currSounds;

        public List<AudioClip> daveSounds;
        public List<AudioClip> burdSounds;

    //Backgrounds

        public GameObject Background;
        private Sprite newBackground;
        public Sprite backgroundImage1;
        public Sprite backgroundImage2;

//track current dialogue
        int dia;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dia = 0;
        //int level = game or main manager.getLevel()
        //int character = game or main manager.getCharacter()
    
        int level = MainManager.instance.level;

        setPlayer();


        if (level == 1)
        {
            currSprites = daveSprites;
            currSounds = daveSounds;
            newBackground = backgroundImage1;
        }
        else {
            currSprites = tartraSprites; 
            currSounds = burdSounds;
            newBackground = backgroundImage2;
        }
       
        Background.GetComponent<SpriteRenderer>().sprite = newBackground;
        Speaker.GetComponent<SpriteRenderer>().sprite = currSprites[0];
        setAudio(level);
        mainAudio.Play();
    

        currDialogue = dialogueManager.getDialogue(level);

        
        dialogue.text = currDialogue[0].getString();
        mainAudio.PlayOneShot(currSounds[currDialogue[dia].getSound()]);

    }

    void setPlayer()
    {
        if (MainManager.instance.player == 0)
        {
            opila.SetActive(true);
        }
        else if (MainManager.instance.player == 1)
        {
            tartra.SetActive(true);
        }
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
            int spriteNumber = currDialogue[dia].getFace();
            int audioNumber = currDialogue[dia].getSound();
             dialogue.text = currDialogue[dia].getString();
             mainAudio.PlayOneShot(currSounds[audioNumber]);
             Speaker.GetComponent<SpriteRenderer>().sprite = currSprites[spriteNumber];
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
