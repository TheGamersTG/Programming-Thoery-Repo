using Unity.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{


private float ySpawnPos = 4.5f;
    public int HP = 5;

    public int speed = 5;

    private int xLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generateMaxX();
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xLimit){
        Movement();
        }
    }

    void Movement(){
            transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    void generateMaxX(){
        xLimit = Random.Range(8, 12);
    }

    public void takeDamage(){
        if (HP > 0){
            HP = HP - 1;
        }
        else {
            Destroy(gameObject);
        }

    }

        Vector3 RandomSpawnPos(){
        return new Vector2(15,  Random.Range(-ySpawnPos, ySpawnPos));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Projectile")){
            takeDamage();
        }
    }
}
