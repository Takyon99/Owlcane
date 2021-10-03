using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PauseMenuScript : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject pauseMenu;

    bool isResume = false;
    bool isRestart = false;
    bool isQuit = false;


    public GameObject resumeButton;
    public GameObject restartButton;
    public GameObject quitButton;
    


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

        if (isPaused)
        {
            PauseAnimation();
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
        resumeButton.GetComponent<Button>().Select();
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

    public void PauseAnimation()
    {
        if(EventSystem.current.currentSelectedGameObject == resumeButton && !isResume)
        {
            isResume = true;
            isRestart = false;
            isQuit = false;

            resumeButton.transform.DOScale(1.1f, 0.5f).SetUpdate(true);
            restartButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            quitButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
        }
        else if (EventSystem.current.currentSelectedGameObject == restartButton && !isRestart)
        {
            isResume = false;
            isRestart = true;
            isQuit = false;

            resumeButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            restartButton.transform.DOScale(1.1f, 0.5f).SetUpdate(true);
            quitButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);

        }
        else if (EventSystem.current.currentSelectedGameObject == quitButton && !isQuit)
        {
            isResume = false;
            isRestart = false;
            isQuit = true;

            resumeButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            restartButton.transform.DOScale(1.0f, 0.5f).SetUpdate(true);
            quitButton.transform.DOScale(1.1f, 0.5f).SetUpdate(true);
        }
    }
   
}
