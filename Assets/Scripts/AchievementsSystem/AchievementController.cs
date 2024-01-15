using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AchievementNotif _achivNotif;
    [SerializeField]
    private GameObject _player;

    private List<Func<bool>> _achievementFunctions = new List<Func<bool>>();
    private bool _treeCut = false;
    private bool _mobKill = false;
    private bool _crafted = false;
    private bool _redRock = false;
    private bool _healed = false;
    [SerializeField]
    private bool _inDesert = false;

    // Update is called once per frame
    void Start()
    {
        // Add your achievement functions to the list
        _achievementFunctions.Add(Achiv1);
        _achievementFunctions.Add(Achiv2);
        _achievementFunctions.Add(Achiv3);
        _achievementFunctions.Add(Achiv4);
        _achievementFunctions.Add(Achiv5);
        _achievementFunctions.Add(Achiv6);
    }


    void Update()
    {
        bool[] achievements = PlayerData.instance.getAchievements();
        for(int i = 0; i < 6; i++)
        {
            if (!achievements[i + 1])
            {
                bool achievementUnlocked = _achievementFunctions[i].Invoke();
                if(achievementUnlocked)
                {
                    PlayerData.instance.Add(i + 1);
                    _achivNotif.SetOkFlag();
                }
            }
        }
    }

    //cut first tree
    private bool Achiv1()
    {
        return _treeCut;
    }

    // kill first mob
    private bool Achiv2()
    {
        return _mobKill;

    }

    // craft an item
    private bool Achiv3()
    {
        return _crafted;

    }

    // destroy red rock
    private bool Achiv4()
    {
        return _redRock;
    }

    // regenerate life
    private bool Achiv5()
    {
        return _healed;

    }

    //find the desert - walk
    private bool Achiv6()
    {
        return _inDesert;

    }

    public void SetTreeCut(bool val)
    {
        _treeCut = val;
    }

    public void SetMobKill(bool val)
    {
        _mobKill = val;
    }

    public void SetCrafted(bool val)
    {
        _crafted = val;
    }

    public void SetRedRock(bool val)
    {
        _redRock = val;
    }

    public void SetHealed(bool val)
    {
        _healed = val;
    }


    public void SetDesert(bool val)
    {
        _inDesert = val;
    }
}
