using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToBossBattle : MonoBehaviour
{

    public void Start()
    {
        PlayerData.instance.setIsInBossBattle(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerData.instance.setIsInBossBattle(true);
            SceneManager.LoadScene("Boss Fight");

        }

    }

}
