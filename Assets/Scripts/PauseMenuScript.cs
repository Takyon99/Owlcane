using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuScript : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject pauseMenu;

    


    void Update()
    {
        if(!isPaused && Input.GetButtonDown("Pause"))
        {
            PauseGame();
        }
        else if(isPaused && Input.GetButtonDown("Pause") || (Input.GetButtonDown("Cancel")))
        {
            ResumeGame();
        }

       
    }

    public void ResumeGame()
    {

        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;

    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
}
