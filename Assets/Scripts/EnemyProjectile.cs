using UnityEngine;

public class EnemyProjectile : Projectile
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame

    public override void Movement()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if(transform.position.x < -xBound){
            Destroy(gameObject);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
