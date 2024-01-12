using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;


public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        Debug.Log("Pressed play");
        //SaveSystem.LoadPlayer();
        SceneManager.LoadScene("SaveMenu");
    }

    public void Settings()
    {
        Debug.Log("Pressed settings");
        SceneManager.LoadScene("Setting Menu");
    }

    public void ToAchievements()
    {
        Debug.Log("Presed achievements");
        SceneManager.LoadScene("Achievements");
    }

    public void ExitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }
}
