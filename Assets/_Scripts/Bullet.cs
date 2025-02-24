using UnityEngine;

public class Bullet : BaseBullet
{
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
	Enemy3Controller enemy3 = collision.GetComponent<Enemy3Controller>();
        if (enemy != null) enemy.ModifyHealth(-damage);
        if (enemy2 != null) enemy2.ModifyHealth(-damage);
	if (enemy3 != null) enemy3.ModifyHealth(-damage);
    }
}
