using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip Select;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad( audioSource );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame(){
        MainManager.instance.level = 1;
        MainManager.instance.SaveLevel();
        audioSource.Stop();
        StartCoroutine(DelayedLoad());
    }

    public void continueGame(){
        audioSource.Stop();
        MainManager.instance.LoadLevel();
        StartCoroutine(DelayedLoad());
    }

    public void exitGame(){
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

     public void settings(){
        audioSource.Stop();
        StartCoroutine(DelayedSettings());
    }


    IEnumerator DelayedLoad(){
        audioSource.PlayOneShot(Select);
        yield return new WaitForSeconds(Select.length);
        SceneManager.LoadScene(2);
    }

       IEnumerator DelayedSettings(){
        audioSource.PlayOneShot(Select);
        yield return new WaitForSeconds(Select.length);
        SceneManager.LoadScene(3);
    }
}
