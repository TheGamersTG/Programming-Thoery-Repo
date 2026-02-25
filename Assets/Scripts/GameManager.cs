using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = true;

    public List<GameObject> Enemies;

    public GivMeter meter;


    public TextMeshProUGUI Score;

    public GameObject Shockwave;

    public TextMeshProUGUI HScore;

    public GameObject gameOverScreen;

    public WinScreen w;
    public TextMeshProUGUI gameOverScore;

    public TextMeshProUGUI HP;

    public GameObject UltPrompt;



    public TextMeshProUGUI gameOverHS;

    public AudioSource mainAudio;

    public AudioClip gameOverSong;

    public List<GameObject> powerUps;

    public float spawnRate = 5.0f;

    public int score = 0;

    public int highScore = 0;

    public int index;

    public float Timer = 0;
    private int bossChecker;

    public List<GameObject> Backgrounds;

    //wave test
   //THESE WAVES WILL LATER COME FROM A WAVELIST CLASS THAT HAS ALL THE WAVES. FOR NOW THEY HERE
    private Wave wave1;
    private Wave wave2;
        private Wave wave3;


    private List<Wave> waves;

    private int currWave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currWave = 0;
        //CHECK THE LEVEL. GET THE WAVES BASED ON CURRENT LEVEL. THIS IS BASIC CODE FOR NOW
        //waves = waveManager.getLevelWaves(Level)
        waves = new List<Wave>();
        wave1 = new Wave(0, new List<GameObject>{Enemies[1], Enemies[0]}, new List<Vector2>{new Vector2(0, 0), new Vector2(0, 0)}, 1f, false);
        wave2 = new Wave(0, new List<GameObject>{Enemies[1], Enemies[0], Enemies[2]}, new List<Vector2>{new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0)}, 10f, false);
        wave3 = new Wave(0, new List<GameObject>{Enemies[3], Enemies[0]}, new List<Vector2>{new Vector2(0, 0), new Vector2(0, 0)}, 10f, true);
        waves.Add(wave1);
        waves.Add(wave2);
        waves.Add(wave3);
        bossChecker = 0;
        //StartCoroutine(SpawnEnemies());
        StartCoroutine(spawnWave());
        setBackground();
        meter = GameObject.Find("GivMeter").GetComponent<GivMeter>();
    }

    IEnumerator spawnWave()
    {
        while(isGameActive){
        //get current wave
        Wave currentWave = waves[currWave];
        
        //check that there is a current wave
        if (currentWave != null){

            yield return new WaitForSeconds(currentWave.getTime());
            //check if this is a boss wave
            
        //wait out the timer for this wave to start
                    
        //get the list of positions
        List <Vector2> positions = currentWave.getPostions();

        int currPos = 0;
        //for each enemy in this wave
        foreach (GameObject enemy in currentWave.getEnemies())
        {
            //spawn them at this position.
            Instantiate(enemy, positions[currPos], Quaternion.identity);
            ++currPos;
        }

        if (!currentWave.CheckifBossWave()){
        ++currWave; //increase index to move on to next wave
            }
            else
            {
                Debug.Log("BOSS TIME!");
                yield break;
                //do nothing atm, but it would change music and mayyybe? randomly spawning enemies
            }
        }
        else
        {
            StartCoroutine(SpawnEnemies());
        }
        }

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
            Instantiate(Enemies[index]);
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

    public void updateMeter(float update)
    {
        meter.UpdateSlider(update);

        if (getMeter() == 1)
        {
            UltPrompt.SetActive(true);
        }
    }

    public float getMeter()
    {
        return meter.getSlider();
    }

    public void resetMeter()
    {
        meter.resetSlider();
        UltPrompt.SetActive(false);
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
