using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    private bool canShoot = true;

    private float AttackSpeedBufDuration = 10f;
    
    private float invincibiltyDuration = 7f;

    private GameManager gameman;

    private float attackTimer;

    public PauseMenu P;
    private float horizontalInput;

    private float timeToShoot = 0.2f;
    private float iFrames = 2;

    private float leftBound = -3.1f;
    
    private float verticalBound = 1.6f;

    public AudioSource PlayerAudio;

    public AudioClip shoot;
    public AudioClip owie;
    public AudioClip death;


    private int HP = 3;

    private bool IsAttackSPDBuffed = false;

    private bool canBeHit = true;



    private float verticalInput;

    public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameman.updateHP(HP);
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

    public void attackSpdBuff()
    {
        if (!IsAttackSPDBuffed){
        timeToShoot = timeToShoot / 2;
        IsAttackSPDBuffed = true;
        StartCoroutine(AttackSpd());
        }
    }

       public void Invinciblability()
    {
        canBeHit = false;
        StartCoroutine(Invincible());

    }
// ABSTRACTION
    public void changeHP(int hpAmount){
        int oldHP = HP;
        HP += hpAmount;
        if (oldHP > HP){
        if (HP != 0){
            PlayerAudio.PlayOneShot(owie);
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
        gameman.updateHP(HP);
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


        IEnumerator Invincible(){
        yield return new WaitForSeconds(invincibiltyDuration);
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

         IEnumerator AttackSpd(){
            yield return new WaitForSeconds(AttackSpeedBufDuration);
            timeToShoot = timeToShoot * 2;
            IsAttackSPDBuffed = false;
        }

}
