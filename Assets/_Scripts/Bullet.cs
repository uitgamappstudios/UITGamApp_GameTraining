using UnityEngine;

public class Bullet : BaseBullet
{
    public override void SetDirection(Vector3 direction)
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
        if(collision.CompareTag("Enemy"))
        {
            // tru mau Enemy
            BaseEnemy enemy =  collision.GetComponent<BaseEnemy>();
            if (enemy != null)
            {
                enemy.ModifyHealth(-damage);
            }
            BulletPooling.Instance.ReturnBullet(this, BulletType.PlayerBullet);
        }

    }
}
