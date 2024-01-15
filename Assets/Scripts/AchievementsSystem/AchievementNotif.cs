using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementNotif : MonoBehaviour{
    [SerializeField]
    private GameObject _achievNotif;

    private float _currentTimer;
    private bool _okFlag = false;

    void Start()
    {
        _currentTimer = 0.0f;
        _achievNotif.SetActive(false);
    }

    void Update()
    {
        _currentTimer += Time.deltaTime;

        if(_okFlag && _currentTimer > 2.0f)
        {
            _okFlag = false; // Reset the flag
            _achievNotif.SetActive(false);
        }

    }

    public void SetOkFlag()
    {
        _okFlag = true;
        _currentTimer = 0f;
        _achievNotif.SetActive(true);
    }


}
