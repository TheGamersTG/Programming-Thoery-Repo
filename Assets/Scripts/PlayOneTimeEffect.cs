using System.Collections;
using UnityEngine;

public class PlayOneTimeEffect : MonoBehaviour
{
    private Animator ani;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ani = GetComponent<Animator>();
        ani.SetTrigger("Play");
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(ani.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
