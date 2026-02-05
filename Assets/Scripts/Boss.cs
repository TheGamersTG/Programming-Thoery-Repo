using UnityEngine;

public class Boss : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //INHERITANCE

    private int direction = 1;
    void Start()
    {
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
        HP = 50;
        speed = 1;
        xLimit = 1;
        transform.position = new Vector2(4, 0);
        scorePoints = 6;
    }
    //POLYMORPHISM

    void Update()
    {
        if (transform.position.x > xLimit){
            Movement();
        }
    }

    // Update is called once per frame
    public override void Movement()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
