using System;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
        public List<DialogueString> failure = new List<DialogueString>();

    public List<DialogueString> dialogue1 = new List<DialogueString>();

        public List<DialogueString> dialogue2 = new List<DialogueString>();

    void Start()
    {

        failure.Add(new DialogueString("Failure.", 1, 1));

        
    //The format is the dialogue, the face (based on the position in the list in scene) and the sound effect.
    //DAVE DIALOGUE
      dialogue1.Add(new DialogueString("Hello there, Opila Bird!", 0, 0));  
      dialogue1.Add(new DialogueString("WELCOME TO OPILA SHOOTER", 1, 0));  
      dialogue1.Add(new DialogueString("This dialogue is no finished.", 0, 0));  
      dialogue1.Add(new DialogueString("Why?", 0, 0));  
      dialogue1.Add(new DialogueString("CAUSE IM CRAZY!!!", 1, 0));  

    //BIRD DIALOGUE
      dialogue2.Add(new DialogueString("You must help me, my bird sibling.", 0, 0));  
      dialogue2.Add(new DialogueString("There is another blue bird on the prowl.", 1, 0));  
      dialogue2.Add(new DialogueString("We cannot allow this.", 1, 0));  
      dialogue2.Add(new DialogueString("Kill him.", 0, 0));  
    }


    public List<DialogueString> getDialogue(int level)
    {
        if (level == 1)
        {
            return dialogue1;
        }

        if (level == 2)
        {
            return dialogue2;
        }

        return failure;
    }
}
