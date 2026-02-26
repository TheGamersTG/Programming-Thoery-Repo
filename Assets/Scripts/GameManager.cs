using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

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

    public PauseMenu P;



    public TextMeshProUGUI gameOverHS;

    public AudioSource mainAudio;

public AudioSource SFXManager;


    public AudioClip gameOverSong;

    public List<GameObject> powerUps;

    public float spawnRate = 5.0f;

    public int score = 0;

    public int highScore = 0;

    public int index;

    public float Timer = 0;
    public List<GameObject> Backgrounds;

    //wave test
   //THESE WAVES WILL LATER COME FROM A WAVELIST CLASS THAT HAS ALL THE WAVES. FOR NOW THEY HERE
      
    public WaveManager waveMan;
    private List<Wave> waves;

    public int currWave;

    //PlayerCharacters

    private PlayerController player;

    public PlayerController OpilaBird;

    public PlayerController TartraBird;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setCharacter();
        currWave = 0;
        waves = waveMan.GetWaveByLevel();
        //StartCoroutine(SpawnEnemies());
        StartCoroutine(spawnWave());
        setBackground();
        meter = GameObject.Find("GivMeter").GetComponent<GivMeter>();
    }

    public void setCharacter()
    {
        if (MainManager.instance.player == 0)
        {
            player = OpilaBird;
        }
        else if (MainManager.instance.player == 1)
        {
            player = TartraBird;
        }


        Instantiate(player, new Vector2(-3, 0), Quaternion.identity);

    }


//get the audiosource for sound effects in game
    public AudioSource getSoundManager()
    {
        return SFXManager;
    }

    public PauseMenu getPauseMenu()
    {
        return P;
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
