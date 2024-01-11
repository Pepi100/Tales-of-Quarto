using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenu : MonoBehaviour
{
    public void GoBack()
    {
        Debug.Log("Going from help to settings");
        SceneManager.LoadScene("Setting Menu");
    }
}
