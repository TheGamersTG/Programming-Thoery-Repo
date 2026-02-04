using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{

//INHERITANCE

private float ySpawnPos = 2.0f;
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
            EnemyAudio.PlayOneShot(death);
            gameman.score += scorePoints;
            Destroy(gameObject);
        }

    }

    public Vector2 RandomSpawnPos(){
        return new Vector2(5,  Random.Range(-ySpawnPos, ySpawnPos));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile")){
            takeDamage();
        }
    }
}
