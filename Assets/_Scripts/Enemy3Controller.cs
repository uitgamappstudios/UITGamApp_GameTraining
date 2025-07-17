using UnityEngine;

public class Enemy3Controller : BaseEnemy
{
    [SerializeField] private int _bulletCount = 6;
    private float _currentHealth;
    private float _timer = 0;
    private float _shootDelay = 0.2f;
    private int _bulletIndex = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _currentHealth = maxHealth;
    }
    void Shoot(int bulletIndex)
    {
        AudioManager.Instance.PlaySoundFXClipWithID("enemy_shoot", transform, 1f);
        float angle = 360 / _bulletCount;
        var bullet = BulletPooling.Instance.GetBullet(BulletType.EnemyBullet);
        bullet.transform.position = transform.position;
        bullet.SetDirection(new Vector3(Mathf.Cos(((bulletIndex - 1) * angle) * Mathf.Deg2Rad),
            Mathf.Sin(((bulletIndex - 1) * angle) * Mathf.Deg2Rad), 0));
    }

    public void Move()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        Vector3 velocity = direction.normalized * speed;
        this.transform.position += velocity * Time.deltaTime;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    void Update()
    {
        Move();
        if ((_bulletIndex > 0 && _timer > _shootDelay) || _timer >= shootCoolDown)
        {
            Shoot(++_bulletIndex);
            _timer = 0;
            if(_bulletIndex == _bulletCount) _bulletIndex = 0;
        }
        else _timer += Time.deltaTime;
    }
}