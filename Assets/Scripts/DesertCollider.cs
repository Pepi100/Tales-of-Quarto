using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertCollider : MonoBehaviour
{
    private AchievementController _achivController;

    public void Start()
    {
        _achivController = GameObject.FindWithTag("AchievementController").GetComponent<AchievementController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("touch");
            _achivController.SetDesert(true);
        }

    }
}
