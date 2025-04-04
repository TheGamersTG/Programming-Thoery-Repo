using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{


private float ySpawnPos = 4.5f;
    protected int HP = 5;

    public int scorePoints;

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
        Movement();
    }

    public virtual void Movement(){
            transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    public void takeDamage(){
        if (HP > 0){
            HP = HP - 1;
        }
        else {
            gameman.score += scorePoints;
            Destroy(gameObject);
        }

    }

    public Vector2 RandomSpawnPos(){
        return new Vector2(15,  Random.Range(-ySpawnPos, ySpawnPos));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile")){
            takeDamage();
        }
    }
}
