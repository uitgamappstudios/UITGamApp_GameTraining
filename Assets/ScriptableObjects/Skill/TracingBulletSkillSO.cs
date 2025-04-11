using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TracingBulletSkill", menuName = "ScriptableObjects/TracingBulletSkillSO")]
public class TracingBulletSkillSO : SkillSO
{
    private TracingBullet _bullet;
    public override void ActivateSkill()
    {
        PlayerController player = SkillManager.instance.player;
        if (player != null)
        {
            Shoot(player);
        }
    }

    void Shoot(PlayerController player)
    {
        // Chỉ bắn khi người chơi đứng yên và ko có viên đạn dí nào đang bay
        if ((_bullet == null || !_bullet.isActiveAndEnabled) && player.velocity == Vector3.zero)
        {
            GameObject target = FindTarget();
            if (target == null)
                return;

            _bullet = (TracingBullet)BulletPooling.Instance.GetBullet(BulletType.TracingBullet);
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
