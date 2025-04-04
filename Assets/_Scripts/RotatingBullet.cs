using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBullet : BaseBullet
{
    [SerializeField] private float radius; // Bán kính di chuyển của đạn

    private float currentAngle;

    private void Update()
    {
        // Di chuyển viên đạn theo vòng tròn xung quanh player
        if (GameManager.instance.player == null)
            return;

        currentAngle += speed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle), 0) * radius;
        transform.position = GameManager.instance.player.transform.position + offset;
    }

    protected void Destroy() { }

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
            BulletPooling.Instance.ReturnBullet(this, BulletType.RotatingBullet);
        }

    }
}
