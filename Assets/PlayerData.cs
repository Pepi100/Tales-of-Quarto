using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Model;

[System.Serializable]
public class PlayerData : MonoBehaviour
{
    #region Singleton
    public static PlayerData instance;
    private static readonly object padlock = new object();

    private void Awake()
    {
        lock (padlock)
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
    }
    #endregion

    [SerializeField]
    private Vector3Serilization _playerPosition = new Vector3Serilization(new Vector3(0, 0, 0));
    [SerializeField]
    private List<Vector3Serilization> _positionTrees = new List<Vector3Serilization>();
    [SerializeField]
    private List<Vector3Serilization> _positionFlowers = new List<Vector3Serilization>();
    [SerializeField]
    private List<Vector3Serilization> _positionStones = new List<Vector3Serilization>();
    [SerializeField]
    private List<Vector3Serilization> _positionRedStones = new List<Vector3Serilization>();
    //[SerializeField]
    //private List<Vector3Serilization> _positionEnemies = new List<Vector3Serilization>();
    [SerializeField]
    private List<InventoryItemSerilization> _inventoryItems = new List<InventoryItemSerilization>();
    [SerializeField]
    private int _weaponID = 0;
    [SerializeField]
    private bool[] _achievementsIds = new bool[] { false, false, false, false, false, false, false };
    [SerializeField]
    private float _playerHealth = 5;


    //this will not be saved (because it is not serialized)
    private bool _cameFromMainGame = false;
    private bool _gameLoaded = false;

    private bool _isInBossBattle = true;


    public void AddTree(Vector3 position)
    {
        _positionTrees.Add(new Vector3Serilization(position));
    }

    public void AddFlower(Vector3 position)
    {
        _positionFlowers.Add(new Vector3Serilization(position));
    }

    public void AddStone(Vector3 position)
    {
        _positionStones.Add(new Vector3Serilization(position));
    }

    public void AddRedStone(Vector3 position)
    {
        _positionRedStones.Add(new Vector3Serilization(position));
    }

    /*
     * 
    public void AddEnemy(Vector3 position)
    {
        _positionEnemies.Add(new Vector3Serilization(position));
    }
     */

    public void AddItem(InventoryItem item)
    {
        _inventoryItems.Add(new InventoryItemSerilization(item));
    }

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

    public Vector3 getPlayerLocation()
    {
        return _playerPosition.GetValue();
    }

    public List<Vector3Serilization> getPositionTrees()
    {
        return _positionTrees;
    }

    public List<Vector3Serilization> getPositionFlowers()
    {
        return _positionFlowers;
    }

    public List<Vector3Serilization> getPositionStones()
    {
        return _positionStones;
    }

    public List<Vector3Serilization> getPositionRedStones()
    {
        return _positionRedStones;
    }

    /*
    public List<Vector3Serilization> getPositionEnemies()
    {
        return _positionEnemies;
    }
     */

    public List<InventoryItemSerilization> getInventoryItems()
    {
        return _inventoryItems;
    }

    public int getWeaponID()
    {
        return _weaponID;
    }

    public float getHealth()
    {
        return _playerHealth;
    }

    public bool getIsInBossBattle()
    {
        return _isInBossBattle;
    }

    public bool getCameFromMainGame()
    {
        return _cameFromMainGame;
    }

    public bool isGameLoaded()
    {
        return _gameLoaded;
    }

    public void setAchievements(bool[] new_achievementsIds)
    {
        _achievementsIds = new_achievementsIds;
    }

    public void setLocation(Vector3 location)
    {
        _playerPosition = new Vector3Serilization(location);
    }

    public void setHealth(float health)
    {
        _playerHealth = health;
    }

    public void resetArrays()
    {
        _positionTrees = new List<Vector3Serilization>();
        _positionFlowers = new List<Vector3Serilization>();
        _positionStones = new List<Vector3Serilization>();
        _positionRedStones = new List<Vector3Serilization>();
        //_positionEnemies = new List<Vector3Serilization>();
        _inventoryItems = new List<InventoryItemSerilization>();
    }

    public void setCameFromMainGame(bool val)
    {
        _cameFromMainGame = val;
    }
    public void setGameLoaded(bool val)
    {
        _gameLoaded = val;
    }

    public void setAll(PlayerDataDTO data)
    {
        _playerPosition = data.getPlayerLocation();
        _positionTrees = data.getPositionTrees();
        _positionFlowers = data.getPositionFlowers();
        _positionStones = data.getPositionStones();
        _positionRedStones = data.getPositionRedStones();
        //_positionEnemies = data.getPositionEnemies();
        _inventoryItems = data.getInventoryItems();
        _weaponID = data.getWeaponID();
        _achievementsIds = data.getAchievements();
        _playerHealth = data.getHealth();
    }

    public void softSetAll(PlayerSoftDataDTO data)
    {
        _playerPosition = data.getPlayerLocation();
        _positionTrees = data.getPositionTrees();
        _positionFlowers = data.getPositionFlowers();
        _positionStones = data.getPositionStones();
        _positionRedStones = data.getPositionRedStones();
        //_positionEnemies = data.getPositionEnemies();
        _inventoryItems = data.getInventoryItems();
        _weaponID = data.getWeaponID();
        _playerHealth = data.getHealth();
    }

    public void setIsInBossBattle(bool isInBossBattle)
    {
        _isInBossBattle = isInBossBattle;
    }

}

[System.Serializable]
public class PlayerSoftDataDTO
{
    [SerializeField]
    protected Vector3Serilization _playerPosition = new Vector3Serilization(new Vector3(0, 0, 0));
    [SerializeField]
    protected List<Vector3Serilization> _positionTrees = new List<Vector3Serilization>();
    [SerializeField]
    private List<Vector3Serilization> _positionFlowers = new List<Vector3Serilization>();
    [SerializeField]
    private List<Vector3Serilization> _positionStones = new List<Vector3Serilization>();
    [SerializeField]
    private List<Vector3Serilization> _positionRedStones = new List<Vector3Serilization>();
    //[SerializeField]
    //private List<Vector3Serilization> _positionEnemies = new List<Vector3Serilization>();
    [SerializeField]
    protected List<InventoryItemSerilization> _inventoryItems = new List<InventoryItemSerilization>();
    [SerializeField]
    private int _weaponID = -1;
    [SerializeField]
    private float _playerHealth;

    public PlayerSoftDataDTO(Vector3Serilization playerPos,
                            List<Vector3Serilization> treesPos,
                            List<Vector3Serilization> flowersPos,
                            List<Vector3Serilization> stonesPos,
                            List<Vector3Serilization> redStonesPos,
                            //List<Vector3Serilization> enemiesPos,
                            List<InventoryItemSerilization> items,
                            int weaponId,
                            float health)
    {
        _playerPosition = playerPos;
        _positionTrees = treesPos;
        _positionFlowers = flowersPos;
        _positionStones = stonesPos;
        _positionRedStones = redStonesPos;
        //_positionEnemies = enemiesPos;
        _inventoryItems = items;
        _weaponID = weaponId;
        _playerHealth = health;
    }

    public Vector3Serilization getPlayerLocation()
    {
        return _playerPosition;
    }

    public List<Vector3Serilization> getPositionTrees()
    {
        return _positionTrees;
    }

    public List<Vector3Serilization> getPositionFlowers()
    {
        return _positionFlowers;
    }

    public List<Vector3Serilization> getPositionStones()
    {
        return _positionStones;
    }

    public List<Vector3Serilization> getPositionRedStones()
    {
        return _positionRedStones;
    }
    
    /*
    public List<Vector3Serilization> getPositionEnemies()
    {
        return _positionEnemies;
    }
    */

    public List<InventoryItemSerilization> getInventoryItems()
    {
        return _inventoryItems;
    }

    public int getWeaponID()
    {
        return _weaponID;
    }

    public float getHealth()
    {
        return _playerHealth;
    }
}

[System.Serializable]
public class PlayerDataDTO : PlayerSoftDataDTO
{
    [SerializeField]
    private bool[] _achievementsIds = new bool[] { false, true, false, false, false, false, false };
    

    public PlayerDataDTO(Vector3Serilization playerPos, 
                        List<Vector3Serilization> treesPos,
                        List<Vector3Serilization> flowersPos,
                        List<Vector3Serilization> stonesPos,
                        List<Vector3Serilization> redStonesPos,
                        //List<Vector3Serilization> enemiesPos,
                        List<InventoryItemSerilization> items,
                        int weapon,
                        bool[] achivs,
                        float health)
        :base(playerPos, treesPos, flowersPos, stonesPos, redStonesPos, items, weapon, health) //de adaugat enemiesPos
    {
        _achievementsIds = achivs;
    }

    public bool[] getAchievements()
    {
        return _achievementsIds;
    }
}