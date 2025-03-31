using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    #region Singleton
    public static BulletPooling Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    public List<BaseBullet> bulletPrefabs;
    private Dictionary<BulletType, Queue<BaseBullet>> bulletPool = new Dictionary<BulletType, Queue<BaseBullet>>();
    public BaseBullet GetBullet(BulletType bulletType)
    {
        if (!bulletPool.ContainsKey(bulletType))
            bulletPool.Add(bulletType, new Queue<BaseBullet>());

        if (bulletPool[bulletType].Count <= 0)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                var b = Instantiate(bulletPrefabs[(int)bulletType]);
                b.gameObject.SetActive(false);
                bulletPool[bulletType].Enqueue(b);
            }
        }
        var bullet = bulletPool[bulletType].Dequeue();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(BaseBullet bullet, BulletType bulletType)
    {
        bullet.gameObject.SetActive(false);
        bulletPool[bulletType].Enqueue(bullet);
    }
}

public enum BulletType
{
    PlayerBullet, EnemyBullet
}
