using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingsMenu : MonoBehaviour
{

   public AudioMixer audioMixer;
   public void SetVolume (float volume)
    {
       audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
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
}
