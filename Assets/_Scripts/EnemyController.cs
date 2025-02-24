using UnityEngine;

public class EnemyController : BaseEnemyController
{
    [Range(0f, 180f)][SerializeField] private float _angle_offset;

    void Update()
    {
        if (_target == null) return;
        LookAtPlayer();
        Move();
    }

    private void LookAtPlayer()
    {
        Vector3 direction = _target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + _angle_offset;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
