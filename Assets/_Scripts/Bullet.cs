using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    void Update()
    {
        // Di chuyển viên đạn theo hướng đã được thiết lập
        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            OnCollision(collision);
            Destroy(gameObject);
        }
    }
    private void OnCollision(Collider2D collision)
    {
        EnemyController enemy=collision.GetComponent<EnemyController>();
        Enemy2Controller enemy2 = collision.GetComponent<Enemy2Controller>();
        if (enemy != null) enemy.ModifyHealth(-damage);
        if (enemy2 != null) enemy2.ModifyHealth(-damage);
    }
}
