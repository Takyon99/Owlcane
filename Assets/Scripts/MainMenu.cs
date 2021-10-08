using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class MainMenu : MonoBehaviour
{
    //window
    public GameObject creditsWindow;
    public GameObject mainMenu;
    public GameObject optionsWindow;
    //if either menu is currently visible
    public bool optionsOn = false;
    public bool creditsOn = false;
    
    //which button is currently selected
    bool isStart = false;
    bool isOptions = false;
    bool isCredits = false;
    bool isQuit = false;

    //has the button been pressed
    bool isStarting = false;
    bool isCreditsPressed = false;
    bool isOptionsPressed = false;
    bool isQuitting = false;
    //the menu icon that moves depending on selected button
    public GameObject icon;
    //main menu buttons
    public GameObject startButton;
    public GameObject optionsButton;
    public GameObject creditsButton;
    public GameObject quitButton;
    //back buttons for credits and options menu
    public GameObject creditsBack;
    public GameObject optionsBack;
    //locations where the icon moves to
    public Transform startIcon;
    public Transform optionsIcon;
    public Transform creditsIcon;
    public Transform quitIcon;

    //makes sure start is the first button selected
    private void Start()
    {
        startButton.GetComponent<Button>().Select();
    }

    void Update()
    {
        MenuAnimation();
        
        //use of back button to exit these menus
        if(optionsOn && Input.GetButtonDown("Cancel"))
        {
            optionsBack.GetComponent<Button>().onClick.Invoke();
        }

        if(creditsOn && Input.GetButtonDown("Cancel"))
        {
            creditsBack.GetComponent<Button>().onClick.Invoke();
        }
        
    }


 
    //begins the start button coroutine
    public void StartButton()
    {
        if (!isStarting)
        {
            StartCoroutine(StartGame());
        }

    }
    //sets the options menu to be visible
    public void OptionsButton()
    {
        StartCoroutine(Options());
    }
    //makes sure the back button is selected when credits window opens
    public void CreditsButton()
    {
        StartCoroutine(Credits());
    }

    public void QuitButton()
    {
        StartCoroutine(QuitGame());
    }
    //back to the main menu from credits menu
    public void CreditsBackButton()
    {
        StartCoroutine(CreditsBack());
    }
    //back to main menu from options menu
    public void OptionsBackButton()
    {
        StartCoroutine(OptionsBack());
    }
    //start game coroutine
    public IEnumerator StartGame()
    {
        
        isStarting = true;
        //animated the start button press
        Tween pressIn = startButton.transform.DOScale(0.9f, 0.2f);
        yield return pressIn.WaitForCompletion();
        Tween pressOut = startButton.transform.DOScale(1.0f, 0.2f);
        yield return pressOut.WaitForCompletion();
        isStarting = false;
        //loads scene after animation plays
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public IEnumerator QuitGame()
    {
        if (!isQuitting)
        {
            isQuitting = true;
            //animated the start button press
            Tween pressIn = quitButton.transform.DOScale(0.9f, 0.2f);
            yield return pressIn.WaitForCompletion();
            Tween pressOut = quitButton.transform.DOScale(1.0f, 0.2f);
            yield return pressOut.WaitForCompletion();
            isQuitting = false;
            Application.Quit();
        }
    }

    public IEnumerator Credits()
    {
        if (!isCreditsPressed)
        {
            isCreditsPressed = true;
            //animated the start button press
            Tween pressIn = creditsButton.transform.DOScale(0.9f, 0.2f);
            yield return pressIn.WaitForCompletion();
            Tween pressOut = creditsButton.transform.DOScale(1.0f, 0.2f);
            yield return pressOut.WaitForCompletion();         
            //creditsWindow.SetActive(true);            
            Tween Move = creditsWindow.transform.DOMoveY(transform.position.y, 1);
            
            creditsBack.GetComponent<Button>().Select();
            creditsOn = true;
            isCreditsPressed = false;
        }
    }

    public IEnumerator CreditsBack()
    {
        Tween pressIn = creditsBack.transform.DOScale(0.9f, 0.2f);
        yield return pressIn.WaitForCompletion();
        Tween pressOut = creditsBack.transform.DOScale(1.0f, 0.2f);
        yield return pressOut.WaitForCompletion();
        Tween Move = creditsWindow.transform.DOMoveY(transform.position.y - 1000, 1);
        yield return Move.WaitForCompletion();
        //creditsWindow.SetActive(false);
        
        creditsButton.GetComponent<Button>().Select();
        creditsOn = false;
    }

    public IEnumerator Options()
    {
        if (!isOptionsPressed)
        {
            isOptionsPressed = true;
            //animated the start button press
            Tween pressIn = optionsButton.transform.DOScale(0.9f, 0.2f);
            yield return pressIn.WaitForCompletion();
            Tween pressOut = optionsButton.transform.DOScale(1.0f, 0.2f);
            yield return pressOut.WaitForCompletion();
            //optionsWindow.SetActive(true);
            Tween Move = optionsWindow.transform.DOMoveY(transform.position.y, 1);

            optionsBack.GetComponent<Button>().Select();
            optionsOn = true;
            isOptionsPressed = false;
        }
    }
    public IEnumerator OptionsBack()
    {
        Tween pressIn = optionsBack.transform.DOScale(0.9f, 0.2f);
        yield return pressIn.WaitForCompletion();
        Tween pressOut = optionsBack.transform.DOScale(1.0f, 0.2f);
        yield return pressOut.WaitForCompletion();
        Tween Move = optionsWindow.transform.DOMoveY(transform.position.y - 1000, 1);
        yield return Move.WaitForCompletion();
        //optionsWindow.SetActive(false);

        optionsButton.GetComponent<Button>().Select();
        optionsOn = false;
    }


    //handles all menu animation
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
