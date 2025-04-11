using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    #region Singleton
    public static GameDataManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        LoadData();
    }
    #endregion

    private GameData gameData;
    public GameData GameData
    {
        get { return gameData; }
        set
        {
            gameData = value;
            SaveData();
        }
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("GameData"))
        {
            string loadedData = PlayerPrefs.GetString("GameData");
            gameData = JsonUtility.FromJson<GameData>(loadedData);
        }
        else
        {
            gameData = new GameData();
        }
    }

    private void SaveData()
    {
        string dataToSave = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData", dataToSave);

        Debug.Log("Game data saved: " + dataToSave);
    }
}
