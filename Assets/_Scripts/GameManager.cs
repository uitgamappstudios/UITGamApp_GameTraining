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
        LoadData();
    }

    private int score;

    public void AddScore(int amount)
    {
        score += amount;
        SaveData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public void LoadData()
    {
        score = PlayerPrefs.GetInt("Score", 0);
    }

    public int GetScore()
    {
        return score;
    }
}
