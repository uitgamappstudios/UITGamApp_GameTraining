using UnityEngine;

public class EnemyBullet : BaseBullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCollision(collision.GetComponent<PlayerController>());
            BulletManager.Instance.ReturnBullet(this, BulletManager.BulletType.EnemyBullet);
        }
    }
    private void OnCollision(PlayerController player)
    {
        if (player == null) return;
        player.ModifyHealth(-damage);
    }
}
