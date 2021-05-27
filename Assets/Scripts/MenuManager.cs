using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;
    public static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        menu.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1;
    }

    public void Resume()
    {
        gameIsPaused = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    void Pause()
    {
        gameIsPaused = true;
        menu.SetActive(true);
        Time.timeScale = 0;
    }
}
