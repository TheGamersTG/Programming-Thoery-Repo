using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public AudioSource winAudio;

    public AudioClip VictorySong;

    public AudioClip Select;

    public TextMeshProUGUI Score;

    public GameManager gameman;


    public GameObject WINSCREEN;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void win()
    {
        WINSCREEN.SetActive(true);
        Score.text = "Score: " + gameman.getScore();
        winAudio.clip = VictorySong;
        winAudio.Play();
    }

    public void mainMenu()
    {
        winAudio.Stop();
        StartCoroutine(DelayedMenu());
    }

    public void QuitGame()
    {
        winAudio.Stop();
        StartCoroutine(DelayedQuit());
    }

    public void Continue()
    {
        MainManager.instance.level += 1;
        winAudio.Stop();
        StartCoroutine(DelayedContinue());
    }

    IEnumerator DelayedQuit(){
        winAudio.PlayOneShot(Select);
        yield return new WaitForSeconds(Select.length);
        Application.Quit();
    }

    IEnumerator DelayedContinue(){
        winAudio.PlayOneShot(Select);
        yield return new WaitForSeconds(Select.length);
        SceneManager.LoadScene(2); //tghis should load scene 2 aka teh cutscene 
    }

    IEnumerator DelayedMenu(){
        winAudio.PlayOneShot(Select);
        yield return new WaitForSeconds(Select.length);
        SceneManager.LoadScene(0);
    }
    
}
