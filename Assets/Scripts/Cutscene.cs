using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
        public TextMeshProUGUI dialogue;

        public Dialogue dialogueManager;

        public List<String> currDialogue;

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
        //if level = 1:
        // dave.setActive()
        int level = MainManager.instance.level;

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
