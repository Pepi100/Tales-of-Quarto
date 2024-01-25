using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{

    private GameObject ObjectMusic;
    private AudioSource AudioSource;
    [SerializeField]
    public Slider slider;

    public void Start()
    {
        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();
        slider.value = AudioSource.volume;
    }

    public void SetVolume ()
    {
        AudioSource.volume = slider.value;
    }

    public void SetQuality (int qualityIndex)
    {
        Debug.Log(qualityIndex);
       QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
       Screen.fullScreen = isFullscreen;
    }

    public void GoBack()
    {
        bool cameFromMainGame = PlayerData.instance.getCameFromMainGame();
        if(cameFromMainGame)
        {
            Debug.Log("Going from settings to main game");
            SceneManager.LoadScene("MainGame");
        }
        else
        {
            Debug.Log("Going from settings to main menu");
            SceneManager.LoadScene("MainMenu");
        }

    }

    public void GoToHelp()
    {
        Debug.Log("Going from settings to help menu");
        SceneManager.LoadScene("HelpMenu");

    }
}
