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
    //windows
    public GameObject pauseMenu;
    public GameObject optionsMenu;
  
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

    public GameObject optionsBack;
                          

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
        StartCoroutine(Resume());
        
    }
    //pauses the game
    public void PauseGame()
    {
        StartCoroutine(Pause());
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

    public void OptionsButton()
    {
        StartCoroutine(Options());
    }

    public void OptionsBackButton()
    {
        StartCoroutine(OptionsBack());
    }


    public IEnumerator Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        Tween Up = pauseMenu.transform.DOMoveY(transform.position.y, 0.5f).SetUpdate(true).SetEase(Ease.OutBack);
        yield return Up.WaitForCompletion();
        resumeButton.GetComponent<Button>().Select();
    }
    public IEnumerator Resume()
    {
        Tween pressIn = resumeButton.transform.DOScale(0.9f, 0.2f).SetUpdate(true);
        yield return pressIn.WaitForCompletion();
        Tween pressOut = resumeButton.transform.DOScale(1.0f, 0.2f).SetUpdate(true);
        yield return pressOut.WaitForCompletion();
        Tween Down = pauseMenu.transform.DOMoveY(transform.position.y - 1000, 0.5f).SetUpdate(true).SetEase(Ease.InBack);
        yield return Down.WaitForCompletion();
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    IEnumerator Options()
    {
        Tween pressIn = optionsButton.transform.DOScale(0.9f, 0.2f).SetUpdate(true);
        yield return pressIn.WaitForCompletion();
        Tween pressOut = optionsButton.transform.DOScale(1.0f, 0.2f).SetUpdate(true);
        yield return pressOut.WaitForCompletion();
        optionsMenu.SetActive(true);
        Tween PauseUp = pauseMenu.transform.DOMoveY(transform.position.y + 1000, 0.5f).SetUpdate(true);
        Tween OptionsUp = optionsMenu.transform.DOMoveY(transform.position.y, 1f).SetUpdate(true).SetEase(Ease.OutBack);
        yield return OptionsUp.WaitForCompletion();
        pauseMenu.SetActive(false);
        optionsBack.GetComponent<Button>().Select();

    }

    IEnumerator OptionsBack()
    {
        Tween pressIn = optionsBack.transform.DOScale(0.9f, 0.2f).SetUpdate(true);
        yield return pressIn.WaitForCompletion();
        Tween pressOut = optionsBack.transform.DOScale(1.0f, 0.2f).SetUpdate(true);
        yield return pressOut.WaitForCompletion();
        pauseMenu.SetActive(true);
        Tween PauseDown = pauseMenu.transform.DOMoveY(transform.position.y, 1f).SetUpdate(true).SetEase(Ease.OutBack);
        Tween OptionsDown = optionsMenu.transform.DOMoveY(transform.position.y - 1000, 0.5f).SetUpdate(true);
        yield return OptionsDown.WaitForCompletion();
        optionsMenu.SetActive(false);
        optionsButton.GetComponent<Button>().Select();

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
