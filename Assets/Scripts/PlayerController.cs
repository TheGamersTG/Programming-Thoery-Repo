using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    private bool canShoot = true;

    private GameManager gameman;

    private float attackTimer;

    public PauseMenu P;
    private float horizontalInput;

    private float timeToShoot = 0.2f;
    private float iFrames = 2;

    private float leftBound = -12;
    
    private float verticalBound = 4.5f;

    public AudioSource PlayerAudio;

    public AudioClip shoot;
    public AudioClip owie;
    public AudioClip death;


    private int HP = 3;

    private bool canBeHit = true;



    private float verticalInput;

    public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameman.isGameActive){
        
            if (Keyboard.current.pKey.wasPressedThisFrame)
    {
        P.Pause();
    }

        
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");


        transform.Translate(Vector2.up * verticalInput * Time.deltaTime * speed);

        
        if (Input.GetKey(KeyCode.Space)){
            if(canShoot){
                // ABSTRACTION
                Shoot();
            }
        }

        // ABSTRACTION
        checkBoundary();

        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);

        }
    }

    void Shoot(){
            PlayerAudio.PlayOneShot(shoot);
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            canShoot = false;
            StartCoroutine(ShootCooldownn());
    }
// ABSTRACTION
    void changeHP(int hpAmount){
        if (HP > 1){
            PlayerAudio.PlayOneShot(owie);
            HP = HP + hpAmount;
            canBeHit = false;
            StartCoroutine(IFrames());
        }
        else {
            gameman.mainAudio.Stop();
            gameman.isGameActive = false;
            StartCoroutine(Death());
            //this would be where id put an exploding animation!

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile") || collision.CompareTag("Enemy")){
            Debug.Log("proj hit!");
            if(gameman.isGameActive){
                if (canBeHit == true){
                changeHP(-1);
                }
            }
        }
    }

    void checkBoundary(){
        if (transform.position.x < leftBound){
                    transform.position = new Vector2(leftBound, transform.position.y);
        }

        if (transform.position.x > -leftBound){
                    transform.position = new Vector2(-leftBound, transform.position.y);
        }

        if (transform.position.y > verticalBound){
                    transform.position = new Vector2(transform.position.x, verticalBound);
        }

        if (transform.position.y < -verticalBound){
                    transform.position = new Vector2(transform.position.x, -verticalBound);
        }
    }

        IEnumerator IFrames(){
        yield return new WaitForSeconds(iFrames);
        canBeHit = true;
        }

        IEnumerator ShootCooldownn(){
        yield return new WaitForSeconds(timeToShoot);
        canShoot = true;
        }

        IEnumerator Death(){
            PlayerAudio.PlayOneShot(death);
            yield return new WaitForSeconds(death.length);
            Destroy(gameObject);
            gameman.GameOver();
        }

}
