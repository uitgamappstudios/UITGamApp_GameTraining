using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float _max_speed = 5f;
    [SerializeField] private float _health;
    [Range(0f, 180f)][SerializeField] private float _angle_offset;
    private float _velocity_multiplier;
    private float _currentHealth;
    private Vector3 _velocity = Vector3.zero;

    void Start()
    {
        _currentHealth = _health;
        _velocity_multiplier = Random.Range(1.5f, 5f);
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (_player == null) return;
        LookAtPlayer();
        Move();
    }

    private void LookAtPlayer()
    {
        Vector3 direction = _player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + _angle_offset;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Move()
    {
        Vector3 direction = _player.position - transform.position;
        _velocity = direction.normalized * _velocity_multiplier;

        // Tính tốc độ hiện tại 
        float speed = Mathf.Sqrt(_velocity.x * _velocity.x + _velocity.y * _velocity.y + _velocity.z * _velocity.z);

        // Giới hạn tốc độ nếu vượt quá _max_speed
        if (speed > _max_speed)
        {
            _velocity = (_velocity / speed) * _max_speed;
        }

        transform.position += _velocity * Time.deltaTime;
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
