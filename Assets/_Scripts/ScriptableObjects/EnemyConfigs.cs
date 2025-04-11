using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfig")]
public class EnemyConfigs : ScriptableObject
{
    public List<EnemyConfig> configs;
    public EnemyConfig GetEnemyConfig(int id)
    {
        foreach (var config in configs)
        {
            if (config.id == id)
                return config;
        }
        return null;
    }
}

[Serializable]
public class EnemyConfig
{
    public int id;
    public float maxHealth;
    public float speed;
    public float shootCoolDown;
}