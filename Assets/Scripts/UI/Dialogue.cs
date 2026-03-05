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
      dialogue1Opila.Add(new DialogueString("Hello there, little bird!", 0, 0));  
      dialogue1Opila.Add(new DialogueString("What brings you to my abode?", 1, 1));  
      dialogue1Opila.Add(new DialogueString("You seem lost and confused!", 0, 1));  
      dialogue1Opila.Add(new DialogueString("...", 0, 1)); 
      dialogue1Opila.Add(new DialogueString("Oh. Yeah. Giving dialogue to only one person was easier to code.", 0, 1)); 
      dialogue1Opila.Add(new DialogueString("BUT ANYWAY! I'd love to help you get home, but...", 0, 0));  
      dialogue1Opila.Add(new DialogueString("Well, my home is being attacked by a bunch of crazy Robots!!", 0, 0));  
        dialogue1Opila.Add(new DialogueString("Hm. You look like you could deal with them.", 0, 0));  
        dialogue1Opila.Add(new DialogueString("Clear out these robots, and maybe you'll be able to get your way back into the Garten!", 0, 0));  
      dialogue1Opila.Add(new DialogueString("Hm...? Why are there evil robots after me? Why did I assume you would fight them for me?", 0, 0));  
        dialogue1Opila.Add(new DialogueString("Well....", 0, 0));  
      dialogue1Opila.Add(new DialogueString("CAUSE IM CRAZY!!!", 1, 0));  

      //Tarta

    dialogue1Tarta.Add(new DialogueString("Hello there... uh.. why are you blue?", 0, 1));  
    dialogue1Tarta.Add(new DialogueString("...", 0, 1));  
    dialogue1Tarta.Add(new DialogueString("Oh come on! You literally spoke in your introduction cutscene!", 0, 1));  
    dialogue1Tarta.Add(new DialogueString("...Anyway. I'm... uh... being attacked by Robots...", 0, 1));  
    dialogue1Tarta.Add(new DialogueString("Why are you staring at me like that?", 0, 1));  
    dialogue1Tarta.Add(new DialogueString("...", 0, 1));  
    dialogue1Tarta.Add(new DialogueString("Can you.. uh... beat them?", 0, 1));  
    dialogue1Tarta.Add(new DialogueString("....", 0, 1));  
    dialogue1Tarta.Add(new DialogueString("Whatever. IM CRAZY!", 1, 1));  



    //BIRD DIALOGUE

    //Opila
      dialogue2Opila.Add(new DialogueString("Welcome home, my fellow bird.", 0, 0));  
        dialogue2Opila.Add(new DialogueString("Our children have missed you.", 0, 0));  
        dialogue2Opila.Add(new DialogueString("I presume that you have come here to try and defeat the surgeon.", 0, 0));  
         dialogue2Opila.Add(new DialogueString("However, there is a more pressing matter.", 0, 0));  
      dialogue2Opila.Add(new DialogueString("There is another blue bird on the prowl.", 1, 1));  
      dialogue2Opila.Add(new DialogueString("We cannot allow this.", 1, 0));  
      dialogue2Opila.Add(new DialogueString("Kill him.", 0, 1));  
     dialogue2Opila.Add(new DialogueString("And then, we shall find the surgeon.", 0, 1));  

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
