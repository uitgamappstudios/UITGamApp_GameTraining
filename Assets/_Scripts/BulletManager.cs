using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public enum BulletType
    {
        PlayerBullet,
        EnemyBullet,
        TracingBullet,
        RotatingBullet
    }
    #region Singleton
    private static BulletManager _instance;
    public static BulletManager Instance => _instance;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    public List<BaseBullet> _pfBullets;
    public Dictionary<int, Queue<BaseBullet>> bulletPool;

    void Start()
    {
        InitPooling();
    }

    void InitPooling()
    {
        if (bulletPool == null)
            bulletPool = new Dictionary<int, Queue<BaseBullet>>();

        for (int i = 0; i < _pfBullets.Count; i++)
        {
            if (!bulletPool.ContainsKey(i) || bulletPool[i] == null)
                bulletPool[i] = new Queue<BaseBullet>();
        }

        int amount = 10;
        for (int i = 0; i < _pfBullets.Count; i++)
        {
            for (int j = 0; j < amount; j++)
            {
                BaseBullet bullet = Instantiate(_pfBullets[i], this.transform);
                bullet.gameObject.SetActive(false);
                bulletPool[i].Enqueue(bullet);
            }
        }
    }

    // Lấy 1 viên đạn ra để bắn
    public BaseBullet GetBullet(BulletType type)
    {
        int index = (int)type;
        if (bulletPool[index].Count <= 0)
        {
            InitPooling();
        }
        BaseBullet b = bulletPool[index].Dequeue();
        b.gameObject.SetActive(true);
        return b;
    }

    // Trả viên đạn vào pool
    public void ReturnBullet(BaseBullet b, BulletType type)
    {
        b.gameObject.SetActive(false);
        bulletPool[(int)type].Enqueue(b);
    }
}