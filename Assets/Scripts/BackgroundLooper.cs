using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float scrollSpeed = 0.1f;

    public int xBound = -15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
     if (transform.position.x < -7)
        {
            transform.position = new Vector3(7, transform.position.y);
        }
        else
         {            
            transform.position = new Vector3(transform.position.x - scrollSpeed, transform.position.y);
     }
    }
}
