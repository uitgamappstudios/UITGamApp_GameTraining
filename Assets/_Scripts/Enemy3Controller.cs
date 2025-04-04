using UnityEngine;

public class Enemy3Controller : BaseEnemy
{
    [SerializeField] private float _shootCooldown = 0.3f;
    [SerializeField] private float _health;
    [SerializeField] private int _bulletCount = 6;
    private float _timer = 0;
    private float _shootDelay = 0.2f;
    private int _bulletIndex = 0;

    protected override void Start()
    {
        base.Start();
    }
    void Shoot(int bulletIndex)
    {
        float angle = 360 / _bulletCount;
        var bullet = BulletPooling.Instance.GetBullet(BulletType.EnemyBullet);
        bullet.transform.position = transform.position;
        bullet.SetDirection(new Vector3(Mathf.Cos(((bulletIndex - 1) * angle) * Mathf.Deg2Rad),
            Mathf.Sin(((bulletIndex - 1) * angle) * Mathf.Deg2Rad), 0));
    }

    void Update()
    {
        Move();
        if ((_bulletIndex > 0 && _timer > _shootDelay) || _timer >= _shootCooldown)
        {
            Shoot(++_bulletIndex);
            _timer = 0;
            if(_bulletIndex == _bulletCount) _bulletIndex = 0;
        }
        else _timer += Time.deltaTime;
    }
}