using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PauseMenuScript : MonoBehaviour
{
    //is the game paused
    public static bool isPaused = false;
    //the pause menu game object
    public GameObject pauseMenu;

    //which button is currently selected
    bool isResume = false;
    bool isRestart = false;
    bool isOptions = false;
    bool isQuit = false;

    //button game objects
    public GameObject resumeButton;
    public GameObject restartButton;
    public GameObject optionsButton;
    public GameObject quitButton;
    


    void Update()
    {

        //pause and unpause
        if(!isPaused && Input.GetButtonDown("Pause"))
        {
            PauseGame();
        }
        else if(isPaused && Input.GetButtonDown("Pause") || (Input.GetButtonDown("Cancel")))
        {
            ResumeGame();
        }

        if (isPaused)
        {
            PauseAnimation();
        }
    }
    //unpauses the game
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }
    //pauses the game
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        resumeButton.GetComponent<Button>().Select();
    }
    //quits the game back to the main menu
    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    //restarts the level
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //handles all of the pause menu animation 
    public void PauseAnimation()
    {
        if(EventSystem.current.currentSelectedGameObject == resumeButton && !isResume)
        {
            isResume = true;
            isRestart = false;
            isOptions = false;
            isQuit = false;

            resumeButton.transform.DOScale(1.1f, 0.5f).SetUpdate(true);
            restartButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            optionsButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            quitButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
        }
        else if (EventSystem.current.currentSelectedGameObject == restartButton && !isRestart)
        {
            isResume = false;
            isRestart = true;
            isOptions = false;
            isQuit = false;

            resumeButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            restartButton.transform.DOScale(1.1f, 0.5f).SetUpdate(true);
            optionsButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            quitButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);

        }

        else if (EventSystem.current.currentSelectedGameObject == optionsButton && !isOptions)
        {
            isResume = false;
            isRestart = false;
            isOptions = true;
            isQuit = false;

            resumeButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            restartButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            optionsButton.transform.DOScale(1.1f, 0.5f).SetUpdate(true);
            quitButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
        }
    
        else if (EventSystem.current.currentSelectedGameObject == quitButton && !isQuit)
        {
            isResume = false;
            isRestart = false;
            isOptions = false;
            isQuit = true;

            resumeButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            restartButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            optionsButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            quitButton.transform.DOScale(1.1f, 0.5f).SetUpdate(true);
        }
    }
   
}
