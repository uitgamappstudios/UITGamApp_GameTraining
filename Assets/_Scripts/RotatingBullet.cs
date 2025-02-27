using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBullet : BaseBullet
{
    [SerializeField] private float radius; // Bán kính di chuyển của đạn

    private float currentAngle;
    private PlayerController player;

    public void SetPlayer(PlayerController player)
    {
        this.player = player;
    }

    protected override void Update()
    {
        // Di chuyển viên đạn theo vòng tròn xung quanh player
        if (player == null)
            return;

        currentAngle += speed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle), 0) * radius;
        transform.position = player.transform.position + offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            OnCollision(collision);
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
