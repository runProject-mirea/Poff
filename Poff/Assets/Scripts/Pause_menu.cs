using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Button_Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Button_Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Button_Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }
    public void Button_Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

