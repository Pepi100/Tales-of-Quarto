using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    public GameObject activeAchievement;
    public GameObject inactiveAchievement;

    private void OnEnable()
    {
        activeAchievement.SetActive(true);
        inactiveAchievement.SetActive(false);
    }

    private void OnDisable()
    {
        activeAchievement.SetActive(false);
        inactiveAchievement.SetActive(true);
    }
}
