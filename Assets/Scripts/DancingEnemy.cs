using UnityEngine;

public class DancingEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private float topBound = 4.5f;
    private int direction = 1;
    void Start()
    {
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
        HP = 3;
        speed = 5;
        xLimit = -15;
        transform.position = RandomSpawnPos();
        scorePoints = 6;
    }

    // Update is called once per frame
    public override void Movement(){

        if (transform.position.y > topBound){
            direction = -1;
            transform.position = new Vector3(transform.position.x -1, topBound);
        }
        else if (transform.position.y < -topBound){
            direction = 1;
            transform.position = new Vector3(transform.position.x -1, -topBound);
        }

        transform.Translate(Vector2.up * Time.deltaTime * speed * direction);


        if(transform.position.x < xLimit){
            Destroy(gameObject);
        }
    }
}
