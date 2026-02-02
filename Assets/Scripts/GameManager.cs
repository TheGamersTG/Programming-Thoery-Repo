using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Dynamic;
using UnityEngine.InputSystem.Controls;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = true;

    public List<GameObject> Enemies;

    public TextMeshProUGUI Score;

    public TextMeshProUGUI HScore;

    public GameObject gameOverScreen;
    public TextMeshProUGUI gameOverScore;

    public TextMeshProUGUI gameOverHS;

    public AudioSource mainAudio;

    public AudioClip gameOverSong;


    public float spawnRate = 5.0f;

    public int score = 0;

    public int highScore = 0;

    public int index;

    public float Timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemies());

    }

    IEnumerator SpawnEnemies()
    {
        while(isGameActive){
            yield return new WaitForSeconds(spawnRate);
            index = getIndex();
            Instantiate(Enemies[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
     Timer += Time.deltaTime;  

     if (Timer > 10.0f){
        if (spawnRate > 1){
        spawnRate = spawnRate - 0.25f;
        }
        Timer = 0;
     }

        if (!isGameActive){
            if (Input.GetKey(KeyCode.R))
            {
                RestartGame();
                Time.timeScale = 1;
            }
        }

        if (score > MainManager.instance.HScore){
            MainManager.instance.HScore = score;
        }

    Score.text = "Score: " + score;
    HScore.text = "High Score: " +  MainManager.instance.HScore;


    }

    public void GameOver(){
        mainAudio.PlayOneShot(gameOverSong);

        MainManager.instance.SaveScore();
        Time.timeScale = 0;
        isGameActive = false;
        gameOverScreen.SetActive(true);
        gameOverScore.text = "Score: " + score;
        gameOverHS.text = "High Score: " + MainManager.instance.HScore;

    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    int getIndex(){
        int currIndex;

        int randomNum = Random.Range(0, 100);

        if (randomNum <= 30){
            currIndex = 1;
        }
        else if (randomNum <= 80){
            currIndex = 0;
        }
        else{
            currIndex = 2;
        }

        return currIndex;
    }


}
