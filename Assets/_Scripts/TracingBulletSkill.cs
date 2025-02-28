using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
            GameObject target = FindTarget();
            if (target == null)
                return;

            _bullet = (TracingBullet)BulletManager.Instance.GetBullet(BulletManager.BulletType.TracingBullet);
            _bullet.transform.position = player.transform.position;
            _bullet.SetTarget(target);
        }
    }

    // Thiết lập mục tiêu cho viên đạn
    GameObject FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
            return null;
        return enemies[Random.Range(0, enemies.Length)];
    }
}
