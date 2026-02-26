using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject Posmen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Continue();
        }

    }

    public void Pause()
    {
        Posmen.SetActive(true);
        Time.timeScale = 0;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Continue()
    {
        Posmen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Reest()
    {
                Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
