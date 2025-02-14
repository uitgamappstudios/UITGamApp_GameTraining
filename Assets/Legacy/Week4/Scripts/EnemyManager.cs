using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private BaseEnemy enemyPrefab;
    [SerializeField] GameObject angelPref;
    [SerializeField] GameObject player;
    public float maxCountDown;
    public float countDown;
    GameObject angel;
    

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
            countDown = maxCountDown;
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
    private void Update()
    {
        if (countDown > 0)
        {
            countDown -= 1 * Time.deltaTime;
        }
    }
    public void SpawnEnemy(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Vector3 position = GetRandomPosition();

            var enemy = Instantiate(enemyPrefab, position, Quaternion.identity, this.transform);
            enemies.Add(enemy);
        }
        player.transform.position = new Vector2(0,-4);
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-2, 2);
        float y = Random.Range(-1.4f, 2);
        return new Vector3(x, y);
    }

    public void RemoveEnemy(BaseEnemy enemy)
    {
        enemies.Remove(enemy);

        if (enemies.Count == 0 && countDown <= 0)
        {
            SpawnAngel();
        }
        else if (enemies.Count == 0 && countDown > 0)
        {
            SpawnEnemy(5);
        }
    }

    private void SpawnAngel()
    {
        angel = Instantiate(angelPref, new Vector2(0, 1), Quaternion.identity);
        player.transform.position = new Vector2(0,-4);
    }

    public void destroyAngel()
    {
        if (angel != null)
        {
            Destroy(angel);
            angel=null;
            SpawnEnemy(5);
            countDown=maxCountDown;
        }

    }

}
