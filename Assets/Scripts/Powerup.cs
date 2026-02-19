using UnityEngine;

public class Powerup : MonoBehaviour
{

    private AudioSource audioSource;
    private GameManager gameman;
    protected PlayerController opila;

    private GameObject playerGameObject;

    public AudioClip SFX;
    public int speed = 1;
    private int xBound = -15;

    void Start()
    {
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = gameman.mainAudio;
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
            audioSource.PlayOneShot(SFX);
            Destroy(gameObject);
        }
    }

    public virtual void PowerUp()
    {
        //Blank
    }

}
