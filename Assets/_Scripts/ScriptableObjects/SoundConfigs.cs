using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundConfigs", menuName = "SoundConfigs")]
public class SoundConfigs : ScriptableObject
{
    public List<SoundConfig> configs;
    public AudioClip GetAudioClip(string id)
    {
        foreach (var config in configs)
        {
            if (config.id == id)
                return config.sound;
        }
        return null;
    }
}

[Serializable]
public class SoundConfig
{
    public string id;
    public AudioClip sound;
}