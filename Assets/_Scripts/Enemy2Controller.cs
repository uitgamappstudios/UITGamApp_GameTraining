using UnityEngine;

public class Enemy2Controller : BaseEnemyController
{
    //[SerializeField] private GameObject _prefabBaseBullet;
    [SerializeField] private float _shootCooldown = 0.3f; //Chu kì bắn đạn
    private float _timer = 0;
    void Update()
    {
        if (_target == null) return;
        Shoot();
        Move();
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
                EnemyBullet bullet = (EnemyBullet)BulletManager.Instance.GetBullet(BulletManager.BulletType.EnemyBullet);
                bullet.transform.position = transform.position;

                // Thiết lập hướng bay cho viên đạn
                bullet.SetDirection(directionNormalized);
            }

            _timer = 0; // Đặt lại timer sau khi bắn
        }
    }
}
