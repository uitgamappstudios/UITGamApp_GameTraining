using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingBulletSkill : BaseSkill
{
    public TracingBulletSkill() : base("TracingBullet") { }

    private TracingBullet _bullet;
    public override void Activate()
    {
        PlayerController player = SkillManager.Instance.Player;
        if (player != null)
        {
            Shoot(player);
        }
    }

    void Shoot(PlayerController player)
    {
        // Chỉ bắn khi người chơi đứng yên và ko có viên đạn dí nào đang bay
        if ((_bullet == null || !_bullet.isActiveAndEnabled) && player.Velocity == Vector3.zero)
        {
            _bullet = (TracingBullet)BulletManager.Instance.GetBullet(BulletManager.BulletType.TracingBullet);
            _bullet.transform.position = player.transform.position;
            FindTarget();
        }
    }

    // Thiết lập mục tiêu cho viên đạn
    void FindTarget()
    {
        if (_bullet == null)
            return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
            return;
        GameObject target = enemies[Random.Range(0, enemies.Length)];
        _bullet.SetTarget(target);
    }
}
