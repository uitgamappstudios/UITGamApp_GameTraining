using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingBullet : BaseBullet
{
    private GameObject target;

    public void SetTarget(GameObject target)
    {
        this.target = target;
        SetDirection(target.transform.position - transform.position);
    }

    private void Update()
    {
        if (target != null)
        {
            SetDirection(target.transform.position - transform.position);
        }

        // Di chuyển viên đạn theo hướng đã được thiết lập
        transform.position += direction * speed * Time.deltaTime;
    }

    protected void Destroy()
    {
        BulletPooling.Instance.ReturnBullet(this, BulletType.TracingBullet);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // tru mau Enemy
            EnemyController enemy1 = collision.GetComponent<EnemyController>();
            if (enemy1 != null)
            {
                enemy1.ModifyHealth(-damage);
            }
            else
            {
                Enemy2Controller enemy2 = collision.GetComponent<Enemy2Controller>();
                if (enemy2 != null)
                {
                    enemy2.ModifyHealth(-damage);
                }
                else collision.GetComponent<Enemy3Controller>().ModifyHealth(-damage);
            }
            BulletPooling.Instance.ReturnBullet(this, BulletType.TracingBullet);
        }

    }
}
