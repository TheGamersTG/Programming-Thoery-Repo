using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{

//INHERITANCE

private float ySpawnPos = 1.5f;
    protected int HP = 5;


    public int scorePoints;

    public AudioSource EnemyAudio;
    public AudioClip ouch;
    public AudioClip death;
    protected int speed = 5;

    protected int xLimit;

    public GameManager gameman;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    
    {
        // ABSTRACTION
        Movement();
    }

    public virtual void Movement(){
    }
// ABSTRACTION
    public void takeDamage(){
        if (HP > 0){
            HP = HP - 1;
            EnemyAudio.PlayOneShot(ouch);
        }
        else {
            Debug.Log("ENEMY is dead!");
            Die();
        }

    }

    public virtual void Die()
    {
            EnemyAudio.PlayOneShot(death);
            CreatePowerup();
            gameman.score += scorePoints;
            Destroy(gameObject);
    }

    public Vector2 RandomSpawnPos(){
        return new Vector2(4.5f,  Random.Range(-ySpawnPos, ySpawnPos));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile")){
            takeDamage();
        }

         if(collision.CompareTag("Shockwave")){
            Die();
        }
    }

//spawn powerup on death
    public void CreatePowerup()
    {
        int randomNum = Random.Range(0, 20);
        if (randomNum == 1){ //1 in 20 chance
                Debug.Log("SPAWNING POWERUP!!");
                int index = getIndex();
                Debug.Log("OKAY! MAKING THE POWERUP NOW.");
            Instantiate(gameman.powerUps[index], transform.position, gameman.powerUps[index].transform.rotation);
       // }
    }

//get the powerup to spawn
   int getIndex(){
        int currIndex;

        int randomNum = Random.Range(0, 100);

        if (randomNum <= 10){
            Debug.Log("invic!");
            currIndex = 0; //10% chance for invinc
        }
        else if (randomNum <= 50){
            Debug.Log("speed!");
            currIndex = 2; //40% chance for atk speed
        }
        else{
            Debug.Log("hp!!");
            currIndex = 1; //60% chance for heal
        }

        return currIndex;
    }
    
}
