using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    #region Singleton
    public static SaveSystem instance;
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
    private string _saveName = "SaveData_";
    [SerializeField]
    [Range(0, 3)]
    private int _saveDataIndex = 0;
    private string _extension = ".json";
    private string _defaultSavePath = "Assets\\Scripts\\SaveSystem";

    public void setSaveDataIndex(int saveDataIndex)
    {
        _saveDataIndex = saveDataIndex;
    }

    public int getSaveDataIndex()
    {
        return _saveDataIndex;
    }

    public void SaveData(string dataToSave)
    {
        if (_saveDataIndex == 0)
        {
            Debug.Log("Not loaded a slot!");
            return;
        }
        if(WriteToFile(_saveName + _saveDataIndex + _extension, dataToSave))
        {
            Debug.Log("Successfully saved data!");
        }
    }

    public string LoadData()
    {
        string data = "";
        Debug.Log("Load data SS");
        Debug.Log(_saveDataIndex.ToString());
        if (ReadFromFile(_saveName + _saveDataIndex + _extension, out data, _saveDataIndex))
        {
            Debug.Log("Successfully loaded data!");
        }
        else if(ReadFromFile(_saveName + "0" + _extension, out data, 0))
        {
            Debug.Log("Successfully loaded new game data!");
        }

        return data;
    }

    public bool DeleteData(int idSlot)
    {
        string name = _saveName + idSlot.ToString() + ".json";
        var fullPath = Path.Combine(Application.persistentDataPath, name);

        if (File.Exists(fullPath))
        {
            try
            {
                File.Delete(fullPath);
                Debug.Log("File deleted successfully: " + fullPath);
                return true;
            }
            catch (IOException e)
            {
                Debug.LogError("Error deleting file: " + e.Message);
                return false;
            }
        }
        else
        {
            Debug.LogWarning("File not found: " + fullPath);
            return false;
        }
    }

    private bool WriteToFile(string name, string content)
    {
        var fullPath = Path.Combine(Application.persistentDataPath, name);
        try
        {
            File.WriteAllText(fullPath, content);
            return true;
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving to a file" + e.Message);
            return false;
        }
    }

    private bool ReadFromFile(string name, out string content, int idSlot)
    {
        var fullPath = name;
        
        if (idSlot != 0)
            fullPath = Path.Combine(Application.persistentDataPath, name);
        else
        {
            fullPath = Path.Combine(Application.streamingAssetsPath, name);
            Debug.Log(fullPath);
        }
        

        try
        {
            content = File.ReadAllText(fullPath);
            return true;
        }
        catch (Exception e)
        {
            content = "";
            Debug.LogError("Error reading from a file" + e.Message);
            return false;
        }
    }
}
