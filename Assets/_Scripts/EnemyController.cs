using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float _max_speed = 5f; 
    [Range(0f, 180f)][SerializeField] private float _angle_offset;
    private float _velocity_multifly; 
    private Vector3 _velocity = Vector3.zero;
 
    // Start is called before the first frame update
    void Start()
    {
        _velocity_multifly = Random.Range(1.5f, 5f);
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
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
        _velocity = direction.normalized * _velocity_multifly; 
        _velocity = Vector3.ClampMagnitude(_velocity, _max_speed); // Giới hạn tốc độ tối đa
        Debug.Log(_velocity);
        // Di chuyển nhân vật
        transform.position += _velocity * Time.deltaTime;
    }

}
