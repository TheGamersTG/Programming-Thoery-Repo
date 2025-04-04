using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = true;

    public List<GameObject> Enemies;

    public TextMeshProUGUI Score;

    public float spawnRate = 5.0f;

    public int score = 0;

    public int highScore = 0;

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
            int index = Random.Range(0, Enemies.Count);
            Instantiate(Enemies[index]);
        }
    }

    // Update is called once per frame
    void Update()
    {
     Timer += Time.deltaTime;  

     if (Timer > 10.0f){
        spawnRate = spawnRate + 0.5f;
        Timer = 0;
     }

        if (!isGameActive){
            if (Input.GetKey(KeyCode.R)){
                RestartGame();
            }
        }

    Score.text = "Score: " + score;

    }

    public void GameOver(){
        isGameActive = false;

    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
