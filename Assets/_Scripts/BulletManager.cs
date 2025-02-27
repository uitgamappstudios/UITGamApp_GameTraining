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
    private int _reloadAmount = 10;

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

        for (int i = 0; i < _pfBullets.Count; i++)
        {
            ReloadPooling(i);
        }
    }

    void ReloadPooling(int index)
    {
        for (int j = 0; j < _reloadAmount; j++)
        {
            BaseBullet bullet = Instantiate(_pfBullets[index], this.transform);
            bullet.gameObject.SetActive(false);
            bulletPool[index].Enqueue(bullet);
        }
    }


    // Lấy 1 viên đạn ra để bắn
    public BaseBullet GetBullet(BulletType type)
    {
        int index = (int)type;
        if (bulletPool[index].Count <= 0)
        {
            ReloadPooling(index);
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