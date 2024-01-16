using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseMenu : MonoBehaviour
{
   public void PlayAgain()
   {
        Debug.Log("Pressed play again");
        //play froma another saved state
        PlayerData.instance.setGameLoaded(true);
        SceneManager.LoadScene("MainGame");
   }
   public void MainMenu()
   {
         Debug.Log("Pressed main menu");
         SceneManager.LoadScene("MainMenu");
   }
}
