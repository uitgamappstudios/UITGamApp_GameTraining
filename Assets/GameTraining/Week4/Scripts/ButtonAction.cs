using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonAction : MonoBehaviour
{
    public GameObject enemyManager;
    public GameObject levelUpManager;

    private void Start()
    {
        enemyManager = EnemyManager.Instance.gameObject;
        levelUpManager = LevelUpManager.Instance.gameObject;
        Time.timeScale = 0;
    }


    public void startGame()
    {
        Time.timeScale = 1.0f;
        enemyManager.SetActive(true);
        levelUpManager.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
  
    }
}
