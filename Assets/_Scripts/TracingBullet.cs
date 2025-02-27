using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingBullet : BaseBullet
{
    private GameObject target;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    protected override void Update()
    {
        //Nếu mục tiêu không còn tồn tại thì trả viên đạn về pool
        if (target == null)
        {
            BulletManager.Instance.ReturnBullet(this, BulletManager.BulletType.TracingBullet);
            return;
        }

        // Hướng viên đạn bay theo hướng mục tiêu
        SetDirection(target.transform.position - transform.position);
        base.Update();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            OnCollision(collision);
            BulletManager.Instance.ReturnBullet(this, BulletManager.BulletType.TracingBullet);
        }
    }

    private void OnCollision(Collider2D collision)
    {
        EnemyController enemy = collision.GetComponent<EnemyController>();
        Enemy2Controller enemy2 = collision.GetComponent<Enemy2Controller>();
        Enemy3Controller enemy3 = collision.GetComponent<Enemy3Controller>();
        if (enemy != null) enemy.ModifyHealth(-damage);
        if (enemy2 != null) enemy2.ModifyHealth(-damage);
        if (enemy3 != null) enemy3.ModifyHealth(-damage);
    }
}
