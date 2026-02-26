using System.Collections;
using UnityEngine;

public class Boss : Enemy
{

    public bool isDead; //check the boss died so it doesnt kill it over and over again
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //INHERITANCE
    void Start()
    {
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
        HP = 50;
        speed = 1;
        xLimit = 1;
        transform.position = new Vector2(4, 0);
        scorePoints = 6;
        isDead = false;
    }
    //POLYMORPHISM

    void Update()
    {
        if (transform.position.x > xLimit){
            Movement();
        }
    }
    
    public override void Die()
    {
        if (!isDead){
            isDead = true;
            gameman.mainAudio.Stop();
            gameman.isGameActive = false;
            gameman.Wipe();
            StartCoroutine(Death());
        }
    }

    IEnumerator Death(){
            EnemyAudio.PlayOneShot(death);
            yield return new WaitForSeconds(death.length);
            Destroy(gameObject);
            gameman.Win(); //do gameman.win instead
     }


    // Update is called once per frame
    public override void Movement()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
