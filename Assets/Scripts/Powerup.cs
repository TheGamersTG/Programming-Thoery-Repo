using UnityEngine;

public class Powerup : MonoBehaviour
{

    protected PlayerController opila;

    private GameObject playerGameObject;
    public int speed = 1;
    private int xBound = -15;

    void Start()
    {
          playerGameObject = GameObject.FindWithTag("Player");

          opila = playerGameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if(transform.position.x < xBound){
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            PowerUp();
            Destroy(gameObject);
        }
    }

    public virtual void PowerUp()
    {
        //Blank
    }
}
