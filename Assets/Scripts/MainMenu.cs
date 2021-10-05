using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class MainMenu : MonoBehaviour
{
    Tween start;
    Tween options;
    Tween credits;
    Tween quit;

    public bool optionsOn = false;
    public bool creditsOn = false;
    
    bool isStart = false;
    bool isOptions = false;
    bool isCredits = false;
    bool isQuit = false;

    bool isStarting = false;

    public GameObject icon;

    public GameObject startButton;
    public GameObject optionsButton;
    public GameObject creditsButton;
    public GameObject quitButton;

    public GameObject creditsBack;
    public GameObject optionsBack;

    public Transform startIcon;
    public Transform optionsIcon;
    public Transform creditsIcon;
    public Transform quitIcon;


    private void Start()
    {
        startButton.GetComponent<Button>().Select();
    }

    void Update()
    {
        MenuAnimation();
        

        if(optionsOn && Input.GetButtonDown("Cancel"))
        {
            optionsBack.GetComponent<Button>().onClick.Invoke();
        }

        if(creditsOn && Input.GetButtonDown("Cancel"))
        {
            creditsBack.GetComponent<Button>().onClick.Invoke();
        }
        
    }


 
  
    public void StartButton()
    {
        if (!isStarting)
        {
            StartCoroutine(StartGame());
        }

    }

    public void OptionsButton()
    {
        
        optionsOn = true;
    }

    public void CreditsButton()
    {
        creditsBack.GetComponent<Button>().Select();
        creditsOn = true;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void CreditsBackButton()
    {
        creditsButton.GetComponent<Button>().Select();
        creditsOn = false;
    }

    public void OptionsBackButton()
    {
        optionsButton.GetComponent<Button>().Select();
        optionsOn = false;
    }

    public IEnumerator StartGame()
    {
        isStarting = true;
        Tween pressIn = startButton.transform.DOScale(0.9f, 0.2f);
        yield return pressIn.WaitForCompletion();
        Tween pressOut = startButton.transform.DOScale(1.0f, 0.2f);
        yield return pressOut.WaitForCompletion();
        isStarting = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void MenuAnimation()
    {
        if (EventSystem.current.currentSelectedGameObject == startButton && !isStart )
        {
            isStart = true;
            isOptions = false;
            isCredits = false;
            isQuit = false;
            icon.transform.DOMove(startIcon.position, 0.5f);

            startButton.transform.DOScale(1.1f, 0.5f);
            optionsButton.transform.DOScale(1f, 0.5f);
            creditsButton.transform.DOScale(1f, 0.5f);
            quitButton.transform.DOScale(1f, 0.5f);
        }
        else if (EventSystem.current.currentSelectedGameObject == optionsButton && !isOptions)
        {
            isStart = false;
            isOptions = true;
            isCredits = false;
            isQuit = false;
            icon.transform.DOMove(optionsIcon.position, 0.5f);

            startButton.transform.DOScale(1f, 0.5f);
            optionsButton.transform.DOScale(1.1f, 0.5f);
            creditsButton.transform.DOScale(1f, 0.5f);
            quitButton.transform.DOScale(1f, 0.5f);
        }
        else if (EventSystem.current.currentSelectedGameObject == creditsButton && !isCredits)
        {
            isStart = false;
            isOptions = false;
            isCredits = true;
            isQuit = false;
            icon.transform.DOMove(creditsIcon.position, 0.5f);

            startButton.transform.DOScale(1f, 0.5f);
            optionsButton.transform.DOScale(1f, 0.5f);
            creditsButton.transform.DOScale(1.1f, 0.5f);
            quitButton.transform.DOScale(1f, 0.5f);
        }
        else if (EventSystem.current.currentSelectedGameObject == quitButton && !isQuit)
        {
            isStart = false;
            isOptions = false;
            isCredits = false;
            isQuit = true;
            icon.transform.DOMove(quitIcon.position, 0.5f);

            startButton.transform.DOScale(1f, 0.5f);
            optionsButton.transform.DOScale(1f, 0.5f);
            creditsButton.transform.DOScale(1f, 0.5f);
            quitButton.transform.DOScale(1.1f, 0.5f);
        }
    }

   
    
}
