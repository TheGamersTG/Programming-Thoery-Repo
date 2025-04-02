using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;

    private bool canShoot = true;

    private float attackTimer;
    private float horizontalInput;

    public float timeToShoot = 0.2f;

    private float leftBound = -12;
    
    private float verticalBound = 4.5f;



    private float verticalInput;

    public float speed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");


        transform.Translate(Vector2.up * verticalInput * Time.deltaTime * speed);

        
        if (Input.GetKey(KeyCode.Space)){
            if(canShoot){
                Shoot();
            }
        }

        if (transform.position.x < leftBound){
                    transform.position = new Vector2(leftBound, transform.position.y);
        }

                if (transform.position.y > verticalBound){
                    transform.position = new Vector2(transform.position.x, verticalBound);
        }

                if (transform.position.y < -verticalBound){
                    transform.position = new Vector2(transform.position.x, -verticalBound);
        }

        transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);

}

    IEnumerator ShootCooldownn(){
        yield return new WaitForSeconds(timeToShoot);
        canShoot = true;
        }


    void Shoot(){
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            canShoot = false;
            StartCoroutine(ShootCooldownn());
    }
}
