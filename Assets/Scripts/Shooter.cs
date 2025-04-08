using System.Collections;
using UnityEngine;

public class Shooter : Enemy
{
    //INHERITANCE

    private float timeToShoot = 3;
    bool canShoot = true;

    public GameObject eProjectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scorePoints = 5;
        gameman = GameObject.Find("GameManager").GetComponent<GameManager>();
        generateMaxX();
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xLimit){
        Movement();
        }

        if (canShoot){
        Shoot();
        }


    }

    IEnumerator ShootCooldown(){
        yield return new WaitForSeconds(timeToShoot);
        canShoot = true;
    }

    void generateMaxX(){
        xLimit = Random.Range(8, 12);
    }

    private void Shoot(){
        if (Random.Range(0, 10) < 2){
            Instantiate(eProjectilePrefab, transform.position, eProjectilePrefab.transform.rotation);
            canShoot = false;
            StartCoroutine(ShootCooldown());
        }
    }


}
