using UnityEngine;

public class Enemy3Controller : BaseEnemyController
{
    [SerializeField] private float _shootCooldown = 0.3f;
    [SerializeField] private int _bulletCount = 6;
    private float _timer = 0;

    void Shoot()
    {
        int angle = 360 / _bulletCount;
        for (int i = 0; i < 360; i += angle)
        {
            //GameObject bullet = Instantiate(_prefabBaseBullet, transform.position, Quaternion.identity);
            EnemyBullet bullet = (EnemyBullet)BulletManager.Instance.GetBullet(BulletManager.BulletType.EnemyBullet);
            bullet.transform.position = transform.position;
            bullet.SetDirection(new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), Mathf.Sin(i * Mathf.Deg2Rad), 0));
        }
    }

    void Update()
    {
        if(_timer >= _shootCooldown)
        {
            Shoot();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }
}
