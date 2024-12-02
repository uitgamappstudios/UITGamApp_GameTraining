using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] GameObject startPanel ;
    public GameObject enemyManager;
    public GameObject levelUpManager;

   private void Start() {
        enemyManager=EnemyManager.Instance.gameObject;
        levelUpManager=LevelUpManager.Instance.gameObject;
    }
       
    
    public void startGame(){
        startPanel.SetActive(false);
        enemyManager.SetActive(true);
        levelUpManager.SetActive(true);
    }
}
