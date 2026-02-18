using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = true;

    public List<GameObject> Enemies;


    public TextMeshProUGUI Score;

    public GameObject Shockwave;

    public TextMeshProUGUI HScore;

    public GameObject gameOverScreen;

    public WinScreen w;
    public TextMeshProUGUI gameOverScore;

    public TextMeshProUGUI HP;


    public TextMeshProUGUI gameOverHS;

    public AudioSource mainAudio;

    public AudioClip gameOverSong;


    public float spawnRate = 5.0f;

    public int score = 0;

    public int highScore = 0;

    public int index;

    public float Timer = 0;
    private int bossChecker;

    public List<GameObject> Backgrounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bossChecker = 0;
        StartCoroutine(SpawnEnemies());
        setBackground();

    }

    public void Win()
    {
        w.win();
    }

    IEnumerator SpawnEnemies()
    {
        while(isGameActive){
            yield return new WaitForSeconds(spawnRate);
            index = getIndex();
            bossChecker += 1;
            if (bossChecker != 3){
            Instantiate(Enemies[index]);
            }
            else
            {
                Instantiate(Enemies[3]);
            }
            ;
        }
    }

    public void Wipe()
    {

        Instantiate(Shockwave);

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
             foreach(GameObject projectile in projectiles)
        {
            Destroy(projectile);
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

    public void updateHP(int hp)
    {
        HP.text = " HP: " + hp;
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

    public int getScore()
    {
        return score;
    }
    

    //function to set the background depending on what the level is
    void setBackground()
    {
        if (MainManager.instance.level == 1)
        {
            Backgrounds[0].SetActive(true);
        }
        else if (MainManager.instance.level == 2)
        {
            Backgrounds[1].SetActive(true);
        }
    }


}
