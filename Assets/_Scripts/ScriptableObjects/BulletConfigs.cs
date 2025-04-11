using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "BulletConfig")]
public class BulletConfigs : ScriptableObject
{
    public BulletConfig[] bulletConfigs;
    public BulletConfig GetConfig(BulletType type)
    {
        foreach (var config in bulletConfigs)
        {
            if (config.bulletType == type)
                return config;
        }
        return null;
    }
}

[Serializable]
public class BulletConfig
{
    public BulletType bulletType;
    public float damage;
    public float speed;
}