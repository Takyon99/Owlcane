using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;


public class MainMenu : MonoBehaviour
{
  
    
   

    void Update()
    {
        
    }


 
  
    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingsButton()
    {

    }

    public void CreditsButton()
    {

    }

    public void QuitButton()
    {
        Application.Quit();
    }

    
    
}
