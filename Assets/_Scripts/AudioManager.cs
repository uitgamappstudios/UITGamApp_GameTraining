using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private SoundConfigs soundConfigs;

    private void Start()
    {
        if (backgroundMusic == null) return;
        AudioSource audioSource = Instantiate(musicSource, this.transform.position, Quaternion.identity);
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlaySoundFXClipWithAudioClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        if(audioClip == null) return;

        AudioSource audioSource = Instantiate(soundSource, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        //Huỷ source sau khi phát xong
        Destroy(audioSource.gameObject, clipLength);
    }

    public void PlaySoundFXClipWithID(string id, Transform spawnTransform, float volume)
    {
        AudioClip audioClip = soundConfigs.GetAudioClip(id);

        if (audioClip == null) return;

        AudioSource audioSource = Instantiate(soundSource, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        //Huỷ source sau khi phát xong
        Destroy(audioSource.gameObject, clipLength);
    }
}
