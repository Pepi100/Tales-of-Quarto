using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISaveScene : MonoBehaviour
{
    public void GoBack()
    {
        Debug.Log("Going from save to main menu");
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameIDToScene(int slotID)
    {
        SaveSystem.instance.setSaveDataIndex(slotID);
        PlayerData.instance.setGameLoaded(true);
        Debug.Log("Going from save to main game");
        Debug.Log(SaveSystem.instance.getSaveDataIndex().ToString());
        SceneManager.LoadScene("MainGame");
    }

    public void DeleteLoadSaveID(int slotID)
    {
        SaveSystem.instance.DeleteData(slotID);
        Debug.Log("Pressed delete " + slotID.ToString());
    }
}
