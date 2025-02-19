using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy2Controller : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _max_speed = 5f;
    [SerializeField] private GameObject _prefabBaseBullet;
    [SerializeField] private float _shootCooldown = 0.3f; //Chu kì bắn đạn
    private float _timer = 0;
    private float _currentHealth;
    private GameObject _target;
    private Vector3 _velocity = Vector3.zero;
    [SerializeField] private float speed;
    void Start()
    {
        _currentHealth = _health;
        _target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (_target == null) return;
        Shoot();
        Move();
    }
    private void Move()
    {
        Vector3 direction = _target.transform.position - transform.position;
        _velocity = direction.normalized * this.speed;

        // Tính tốc độ hiện tại 
        float speed = Mathf.Sqrt(_velocity.x * _velocity.x + _velocity.y * _velocity.y + _velocity.z * _velocity.z);

        // Giới hạn tốc độ nếu vượt quá _max_speed
        if (speed > _max_speed)
        {
            _velocity = (_velocity / speed) * _max_speed;
        }

        transform.position += _velocity * Time.deltaTime;
    }
    public void Shoot()
    {
        _timer += Time.deltaTime;

        if ( _timer >= _shootCooldown)
        {
            if (_target != null) // Đảm bảo mục tiêu vẫn còn tồn tại
            {
                // Lấy hướng đến mục tiêu
                Vector3 direction = _target.transform.position - transform.position;

                // Tính độ lớn của direction (magnitude)
                float magnitude = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y + direction.z * direction.z);

                // Tính vector đơn vị (normalized) nếu magnitude > 0 
                Vector3 directionNormalized = new Vector3(0, 0, 0);
                if (magnitude > 0)
                    directionNormalized = direction / magnitude;

                // Tạo viên đạn từ prefab
                GameObject bullet = Instantiate(_prefabBaseBullet, transform.position, Quaternion.identity);

                // Thiết lập hướng bay cho viên đạn
                bullet.GetComponent<EnemyBullet>().SetDirection(directionNormalized);
            }

            _timer = 0; // Đặt lại timer sau khi bắn
        }
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
