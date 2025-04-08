using UnityEngine;

public class FastEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //INHERITANCE

    void Start()
    {
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
        HP = 3;
        speed = 15;
        xLimit = -15;
        transform.position = RandomSpawnPos();
        scorePoints = 3;
    }

    // Update is called once per frame
    //POLYMORPHISM
    public override void Movement(){
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if(transform.position.x < xLimit){
            Destroy(gameObject);
        }
    }
}
