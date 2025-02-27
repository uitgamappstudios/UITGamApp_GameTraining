using UnityEngine;

public class BaseEnemyController : MonoBehaviour
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _max_speed = 5f;
    protected GameObject _target;
    protected float _currentHealth;
    protected Vector3 _velocity = Vector3.zero;
    [SerializeField] protected float _normal_speed;

    protected void Start()
    {
        _currentHealth = _health;
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    protected void Move()
    {
        Vector3 direction = _target.transform.position - transform.position;
        _velocity = direction.normalized * _normal_speed;
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

    protected void Die()
    {
        Destroy(gameObject);
    }
}
