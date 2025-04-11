using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    #endregion

    private void Start()
    {
        score = GameDataManager.Instance.GameData.score;
    }

    private int score;

    public void AddScore(int amount)
    {
        score += amount;
        GameData gameData = GameDataManager.Instance.GameData;
        gameData.score = score;
        GameDataManager.Instance.GameData = gameData;
    }

    public int GetScore()
    {
        return score;
    }
}
