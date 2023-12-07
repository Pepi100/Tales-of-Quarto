using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    #region Singleton
    public static PlayerData instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion


    public float x = 0, y = 0, z = 0;

    private bool[] _achievementsIds = new bool[] { false, true, false, false, false, false, false };
    private bool _isInBossBattle = true;


    ///Call this method with the id of the achievement to mark as checked



    public void Add(int idAchiv)
    {
        if (!_achievementsIds[idAchiv])
            _achievementsIds[idAchiv] = true;
    }

    public void Remove(int idAchiv)
    {
        _achievementsIds[idAchiv] = false;
    }


    ///Getter method
    public bool[] getAchievements()
    {
        return _achievementsIds;
    }



    public float getX()
    {
        return x;
    }

    public float getY()
    {
        return y;
    }

    public float getZ()
    {
        return z;
    }

    public bool getIsInBossBattle()
    {
        return _isInBossBattle;
    }




    public void setAchievements(bool[] new_achievementsIds)
    {
        _achievementsIds = new_achievementsIds;
    }

    public void setX(double newX)
    {
        x = (float)newX;
    }

    public void setY(double newY)
    {
        y = (float)newY;
    }

    public void setZ(double newZ)
    {
        z = (float)newZ;
    }

    public void setIsInBossBattle(bool isInBossBattle)
    {
        _isInBossBattle = isInBossBattle;
    }

}


