using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngineInternal;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    private bool canShoot = true;

    private float AttackSpeedBufDuration = 10f;
    
    private float invincibiltyDuration = 7f;

    private GameManager gameman;

    private float attackTimer;

    private PauseMenu P;
    private float horizontalInput;

    protected float timeToShoot;
    private float iFrames = 2;

    private float leftBound = -3.1f;
    
    private float verticalBound = 1.6f;

    private AudioSource PlayerAudio;


    public AudioClip shoot;
    public AudioClip owie;
    public AudioClip death;


    protected int HP;

    private bool IsAttackSPDBuffed = false;

    private bool isInvicible = false;

    private bool canBeHit = true;

    private SpriteRenderer opilaSprite;
    public Color opilaColor;



    private float verticalInput;

    protected float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        opilaSprite = GetComponent<SpriteRenderer>();
        opilaColor = opilaSprite.color;
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameman.updateHP(HP);
        P = gameman.getPauseMenu();
        PlayerAudio = gameman.getSoundManager();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(canShoot);
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
    

        if (Input.GetKey(KeyCode.U)){
            if(gameman.getMeter() == 1){
                Ultimate();
                gameman.resetMeter();
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
        opilaSprite.color = new Color(1, 0, 0);
        StartCoroutine(AttackSpd());
        }
    }

       public void Invinciblability()
    {
        if (!isInvicible){
        canBeHit = false;
        isInvicible = true;
        opilaSprite.color = new Color(0, 1, 0);
        StartCoroutine(Invincible());
        }

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
        isInvicible = false;
        if (!IsAttackSPDBuffed){
        opilaSprite.color = opilaColor;
        }
        else
        {
            opilaSprite.color= new Color(1, 0, 0);
        }
        }

        IEnumerator ShootCooldownn(){
        Debug.Log("Waiting to shoot!");
        yield return new WaitForSeconds(timeToShoot);
        Debug.Log("You can shoot again");
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
            if (!isInvicible){
            opilaSprite.color = opilaColor;
            }
             else
            {
                opilaSprite.color= new Color(0, 1, 0);
             }
        }

        public void Ultimate()
    {
        gameman.Wipe();
    }

}
