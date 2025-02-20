using UnityEngine;

public class Enemy3Controller : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBaseBullet;
    [SerializeField] private float _shootCooldown = 0.3f;
    [SerializeField] private float _health;
    [SerializeField] private int _bulletCount = 6;
    private float _currentHealth;
    private float _timer = 0;

    void Start()
    {
        _currentHealth = _health;
    }
    void Shoot()
    {
        int angle = 360 / _bulletCount;
        for (int i = 0; i < 360; i += angle)
        {
            GameObject bullet = Instantiate(_prefabBaseBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<EnemyBullet>().SetDirection(new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), Mathf.Sin(i * Mathf.Deg2Rad), 0));
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
    public void ModifyHealth(float delta)
    {
        _currentHealth += delta;
        if (_currentHealth < 0) Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
