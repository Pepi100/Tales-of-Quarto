using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIAchievements : MonoBehaviour
{
    public void GoBack()
    {
        bool cameFromMainGame = PlayerData.instance.getCameFromMainGame();
        if (cameFromMainGame)
        {
            Debug.Log("Going from achievements to main game");
            SceneManager.LoadScene("MainGame");
        }
        else
        {
            Debug.Log("Going from achievements to main menu");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
