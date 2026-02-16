using System;
using UnityEngine;

public class DialogueString
{
   private String dialogue;
   private int face;
   private int sound;

   public DialogueString(String dialogue, int face, int sound)
    {
        this.dialogue = dialogue;
        this.face = face;  
        this.sound = sound;
    }

    public String getString()
    {
        return dialogue;
    }

    
    public int getFace()
    {
        return face;
    }

    
    public int getSound()
    {
        return sound;
    }
}
