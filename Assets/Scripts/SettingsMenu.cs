using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    //menu assets
    public AudioMixer audioMixer;
    public GameObject optionsBack;
    public Slider volume;


    //selects the back button when opening
    private void OnEnable()
    {
        //optionsBack.GetComponent<Button>().Select();
    }

    //sets master volume with slider
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume)* 20);
    }
    //toggle full screen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


}
