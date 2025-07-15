using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public int id;
    public GameObject player;
    public EnemyConfigs enemyConfigs;
    protected EnemyConfig config;
    [SerializeField] protected Animator enemyAnimator;

    public float speed => config.speed;
    public float maxHealth => config.maxHealth;
    public float currentHealth;
    public float shootCoolDown => config.shootCoolDown;

    // Start is called before the first frame update
    void Awake()
    {
        config = enemyConfigs.GetEnemyConfig(id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Die()
    {
        GameManager.instance.AddScore(10);
        Destroy(gameObject);
    }
}
