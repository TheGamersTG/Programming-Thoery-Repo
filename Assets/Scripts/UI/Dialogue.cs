using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Dialogue : MonoBehaviour
{
        public List<DialogueString> failure = new List<DialogueString>();

    public List<DialogueString> dialogue1Opila = new List<DialogueString>();

        public List<DialogueString> dialogue2Opila = new List<DialogueString>();

        public List<DialogueString> dialogue1Tarta = new List<DialogueString>();

        public List<DialogueString> dialogue2Tarta = new List<DialogueString>();

    void Start()
    {

        failure.Add(new DialogueString("Failure.", 1, 1));

        
    //The format is the dialogue, the face (based on the position in the list in scene) and the sound effect.
    //DAVE DIALOGUE
    //Opila
      dialogue1Opila.Add(new DialogueString("Hello there, Opila Bird!", 0, 0));  
      dialogue1Opila.Add(new DialogueString("WELCOME TO OPILA SHOOTER", 1, 1));  
      dialogue1Opila.Add(new DialogueString("This dialogue is no finished.", 0, 1));  
      dialogue1Opila.Add(new DialogueString("Why?", 0, 0));  
      dialogue1Opila.Add(new DialogueString("CAUSE IM CRAZY!!!", 1, 0));  

      //Tarta
    dialogue1Tarta.Add(new DialogueString("Hello there... uh.. why are you blue?", 0, 1));  
        dialogue1Tarta.Add(new DialogueString("DIALOGUE HERE", 0, 1));  
    dialogue1Tarta.Add(new DialogueString("Whatever. IM CRAZY!", 0, 1));  



    //BIRD DIALOGUE

    //Opila
      dialogue2Opila.Add(new DialogueString("You must help me, my bird sibling.", 0, 0));  
      dialogue2Opila.Add(new DialogueString("There is another blue bird on the prowl.", 1, 1));  
      dialogue2Opila.Add(new DialogueString("We cannot allow this.", 1, 0));  
      dialogue2Opila.Add(new DialogueString("Kill him.", 0, 1));  

      //Tarta
      dialogue2Tarta.Add(new DialogueString("You must help me, my...", 0, 0));  
        dialogue2Tarta.Add(new DialogueString("...Interesting?", 1, 1));  
      dialogue2Tarta.Add(new DialogueString("A... an imitation?", 1, 0));  
      dialogue2Tarta.Add(new DialogueString("Regardless. Finish the mission.", 0, 0));  



    }


    public List<DialogueString> getDialogue(int level)
    {
        switch (level){
        case 1:
        if (MainManager.instance.player == 0){
            return dialogue1Opila;
        }
        else if (MainManager.instance.player == 1)
            {
                return dialogue1Tarta;
            }
        break;
        case 2:
        if (MainManager.instance.player == 0){
            return dialogue2Opila;
        }
        else if (MainManager.instance.player == 1)
            {
                return dialogue2Tarta;
            }
        break;
    }
    return failure;
}
}
