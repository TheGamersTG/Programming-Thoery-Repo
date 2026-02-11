using System;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
        public List<String> failure = new List<String>() { " failure. "};
    public List<String> dialogue1 = new List<String>() { 
        "Hello there, little bird! ",
        "Welcome to OPILA SHOOTER ",
        "I need your help. ",
        "This dialogue is not finished. ",
        "Why? CAUSE IM CRAZY! ",
    };

        public List<String> dialogue2 = new List<String>() { 
        "You must help me, my bird sibling. ",
        "There is another blue bird on the prowl. ",
        "We cannot allow this. ",
        "Kill him. ",
        "And I will help you. ",

    };

    public List<String> getDialogue(int level)
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
