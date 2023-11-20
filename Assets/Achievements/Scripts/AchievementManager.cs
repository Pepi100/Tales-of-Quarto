using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{

    private Achievement[] achievements;
    private void Awake()
    {
        ///Get all the achievement elements in the hierarchy, sorted by name
        achievements = FindObjectsOfType<Achievement>(); 
        System.Array.Sort(achievements, (a, b) => a.name.CompareTo(b.name));

        foreach (Achievement achievement in achievements)
        {
            // Access and print information about each achievement
            Debug.Log(achievement.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ///Get all the achievement ids from the player data and check if active
        bool[] achivsIds = PlayerData.instance.getAchievements();
        
        for(int i = 0; i <= 5; ++i){
            if(achivsIds[i+1]){
                achievements[i].enabled = true;
            }
            else{
                achievements[i].enabled = false;
            }
        }
    }

}
