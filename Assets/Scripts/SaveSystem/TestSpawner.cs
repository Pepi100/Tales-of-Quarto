using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class TestSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _tree;
    [SerializeField]
    private List<GameObject> _treesList = new List<GameObject>();
    [SerializeField]
    private GameObject _flower;
    [SerializeField]
    private List<GameObject> _flowersList = new List<GameObject>();
    [SerializeField]
    private GameObject _stone;
    [SerializeField]
    private List<GameObject> _stonesList = new List<GameObject>();
    [SerializeField]
    private GameObject _redStone;
    [SerializeField]
    private List<GameObject> _redStonesList = new List<GameObject>();
    /*
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private List<GameObject> _enemiesList = new List<GameObject>();
     */

    private void Start()
    {
        if (PlayerData.instance.isGameLoaded())
        {
            PlayerData.instance.setGameLoaded(false);
            LoadGame();
        }
        else
        {
            PlaceItems();
        }
    }

    public void Clear()
    {
        foreach (var item in _treesList)
        {
            Destroy(item);
        }
        _treesList.Clear();

        foreach (var item in _flowersList)
        {
            Destroy(item);
        }
        _flowersList.Clear();

        foreach (var item in _stonesList)
        {
            Destroy(item);
        }
        _stonesList.Clear();

        foreach (var item in _redStonesList)
        {
            Destroy(item);
        }
        _redStonesList.Clear();
        /*
        foreach (var item in _enemiesList)
        {
            Destroy(item);
        }
        _enemiesList.Clear();
        */
    }

    public void SaveGame()
    {
        var dataToSave = JsonUtility.ToJson(PlayerData.instance);
        SaveSystem.instance.SaveData(dataToSave);
    }

    public void LoadGame()
    {
        Clear();
        string dataToLoad = "";

        dataToLoad = SaveSystem.instance.LoadData();
        if (!String.IsNullOrEmpty(dataToLoad))
        {
            PlayerDataDTO data = JsonUtility.FromJson<PlayerDataDTO>(dataToLoad);
            PlayerData.instance.setAll(data);
            PlaceItems();
        }
    }

    public void PlaceItems()
    {
        foreach (var positionData in PlayerData.instance.getPositionTrees())
        {
            _treesList.Add(Instantiate(_tree, positionData.GetValue(), Quaternion.identity));
        }

        foreach (var positionData in PlayerData.instance.getPositionFlowers())
        {
            _flowersList.Add(Instantiate(_flower, positionData.GetValue(), Quaternion.identity));
        }

        foreach (var positionData in PlayerData.instance.getPositionStones())
        {
            _stonesList.Add(Instantiate(_stone, positionData.GetValue(), Quaternion.identity));
        }

        foreach (var positionData in PlayerData.instance.getPositionRedStones())
        {
            _redStonesList.Add(Instantiate(_redStone, positionData.GetValue(), Quaternion.identity));
        }
        /*
        foreach (var positionData in PlayerData.instance.getPositionEnemies())
        {
            _redStonesList.Add(Instantiate(_enemy, positionData.GetValue(), Quaternion.identity));
        }
        */
    }

    public List<Vector3Serilization> getTreesLocation()
    {
        List<Vector3Serilization> treesLocationList = new List<Vector3Serilization>();

        foreach (var tree in _treesList)
        {
            if (tree != null)
            {
                treesLocationList.Add(
                    new Vector3Serilization(tree.transform.position)
                    );
            }
        }

        return treesLocationList;
    }

    public List<Vector3Serilization> getFlowersLocation()
    {
        List<Vector3Serilization> flowersLocationList = new List<Vector3Serilization>();

        foreach (var flower in _flowersList)
        {
            if (flower != null)
            {
                flowersLocationList.Add(
                    new Vector3Serilization(flower.transform.position)
                    );
            }
        }

        return flowersLocationList;
    }

    public List<Vector3Serilization> getStonesLocation()
    {
        List<Vector3Serilization> stonesLocationList = new List<Vector3Serilization>();

        foreach (var stone in _stonesList)
        {
            if (stone != null)
            {
                stonesLocationList.Add(
                    new Vector3Serilization(stone.transform.position)
                    );
            }
        }

        return stonesLocationList;
    }

    public List<Vector3Serilization> getRedStonesLocation()
    {
        List<Vector3Serilization> redStonesLocationList = new List<Vector3Serilization>();

        foreach (var stone in _redStonesList)
        {
            if (stone != null)
            {
                redStonesLocationList.Add(
                    new Vector3Serilization(stone.transform.position)
                    );
            }
        }

        return redStonesLocationList;
    }

    /*
    public List<Vector3Serilization> getEnemiesLocation()
    {
        List<Vector3Serilization> enemiesLocationList = new List<Vector3Serilization>();

        foreach (var enemy in _enemyList)
        {
            if (enemy != null)
            {
                enemiesLocationList.Add(
                    new Vector3Serilization(enemy.transform.position)
                    );
            }
        }

        return enemiesLocationList;
    }
    */
}
