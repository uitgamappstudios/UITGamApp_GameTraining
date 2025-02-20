using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnee;
    [SerializeField] private int _spawnAmount;
    Vector2 GetRandomPositionInView()
    {
        Camera cam = Camera.main;
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);
        Vector3 randomViewportPosition = new Vector3(randomX, randomY, cam.nearClipPlane);
        return cam.ViewportToWorldPoint(randomViewportPosition);
    }

    void Start()
    {
        for(int i = 0; i < _spawnAmount; i++)
        {
            Instantiate(_spawnee, GetRandomPositionInView(), Quaternion.identity);
        }
    }
}
