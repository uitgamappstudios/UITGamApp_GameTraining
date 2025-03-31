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

    public BaseBullet bulletPrefab;
    private Queue<BaseBullet> bulletPool = new Queue<BaseBullet>();
    public BaseBullet GetBullet()
    {
        if (bulletPool.Count <= 0)
        {
            int count = 10;
            for (int i = 0; i < count; i++)
            {
                var b = Instantiate(bulletPrefab);
                b.gameObject.SetActive(false);
                bulletPool.Enqueue(b);
            }
        }
        var bullet = bulletPool.Dequeue();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
