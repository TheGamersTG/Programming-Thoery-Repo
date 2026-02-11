using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
        public TextMeshProUGUI dialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //int level = game or main manager.getLevel()
        //int character = game or main manager.getCharacter()
        //if level = 1:
        // dave.setActive()
        int level = MainManager.instance.level;
        if (level == 1){
        dialogue.text = "Wecleom to level 1!!! ENTER TO START";
        }
         if (level == 2){
        dialogue.text = "Wecleom to level 2!!! ENTER TO START";
        }
        if (level == 3){
        dialogue.text = "Wecleom to level 3!!! ENTER TO START";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))            {
                //If dialogue = dialogue.size()
                SceneManager.LoadScene(1);
                //else: dialogueText = dialogue[1]
            }
        }
    
}
