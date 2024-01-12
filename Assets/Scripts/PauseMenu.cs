using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField]
    private SoftSave _softSave;
    // Update is called once per frame
    void Start()
    {
        bool cameFromMainGame = PlayerData.instance.getCameFromMainGame();
        if (cameFromMainGame)
            Pause();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                _softSave.SoftSaveData();
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu ()
    {
       Time.timeScale = 1f;
       SceneManager.LoadScene("MainMenu");

    }

    public void ToSettings()
    {
        Debug.Log("Pressed settings");
        PlayerData.instance.setCameFromMainGame(true);
        SceneManager.LoadScene("Setting Menu");

    }

    public void ToAchievements()
    {
        Debug.Log("Pressed achievements");
        PlayerData.instance.setCameFromMainGame(true);
        SceneManager.LoadScene("Achievements");

    }

    public void ToMainMenu()
    {
        Debug.Log("Pressed to main menu");
        Time.timeScale = 1f;
        PlayerData.instance.setCameFromMainGame(false);
        SceneManager.LoadScene("MainMenu");

    }

    public void SaveGame()
    {
        // save code - attention to save slot
        Debug.Log("Saved");

    }

}
