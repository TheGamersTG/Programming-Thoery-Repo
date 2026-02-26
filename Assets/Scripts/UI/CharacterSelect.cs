using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
  public void Opila()
    {
        MainManager.instance.setPlayer(0);
        //winAudio.Stop();
        StartCoroutine(DelayedContinue());
    }

    public void Tartra()
    {
        MainManager.instance.setPlayer(1);
        //winAudio.Stop();
        StartCoroutine(DelayedContinue());
    }

       IEnumerator DelayedContinue(){
        //audioSource.PlayOneShot(Select);
        //yield return new WaitForSeconds(Select.length);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }


}
