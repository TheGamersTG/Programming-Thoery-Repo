using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{

    private GivMeter meter;

    GameManager gameman;

    protected int xBound = 15;
    protected int speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
            meter = GameObject.Find("GivMeter").GetComponent<GivMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(transform.position.x > xBound){
            Destroy(gameObject);
        }
    }

    public virtual void Movement(){ //i plan to override this for some wacky movement when i implement enemy projectiles!!
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy")){
            gameman.updateMeter(0.05f);
            Destroy(gameObject);
        }
    }
}
