using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    private float scrollSpeed = 6f;

    private int xBound = -8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
     if (transform.position.x < xBound)
        {
            transform.position = new Vector3(7, transform.position.y);
        }
        else
         {            
            transform.position = new Vector3(transform.position.x - (scrollSpeed * Time.deltaTime), transform.position.y);
     }
    }
}
