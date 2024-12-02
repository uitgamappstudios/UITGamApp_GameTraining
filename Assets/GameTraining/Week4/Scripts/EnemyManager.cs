using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private BaseEnemy enemyPrefab;
    [SerializeField] private float rangeX; // Khoảng để spawn enemy
    [SerializeField] private float rangeY;

    private List<BaseEnemy> enemies = new List<BaseEnemy>();

    #region Singleton
    private static EnemyManager instance;

    public static EnemyManager Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    private void Start()
    {
        SpawnEnemy(5);
    }    
    
    public void SpawnEnemy(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 position = GetRandomPosition();

            var enemy = Instantiate(enemyPrefab, position, Quaternion.identity, this.transform);
            enemies.Add(enemy);
        }    
    }   
    
    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-rangeX, rangeX);
        float y = Random.Range(-rangeY, rangeY);
        return new Vector3(x,y);
    }    

    public void RemoveEnemy(BaseEnemy enemy)
    {
        enemies.Remove(enemy); 
        
        if (enemies.Count == 0 )
        {
            SpawnEnemy(5);
        }    
    }    
}
