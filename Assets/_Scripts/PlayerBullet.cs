using UnityEngine;

public class PlayerBullet : BaseBullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            OnCollision(collision);
            Destroy();
        }
    }

    protected virtual void Destroy()
    {
        BulletManager.Instance.ReturnBullet(this, BulletManager.BulletType.PlayerBullet);
    }

    private void OnCollision(Collider2D collision)
    {
        BaseEnemyController enemy = collision.GetComponent<BaseEnemyController>();
        if (enemy != null) enemy.ModifyHealth(-damage);
    }
}
