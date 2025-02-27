using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBulletSkill : BaseSkill
{
    public RotatingBulletSkill() : base("RotatingBullet") { }

    private RotatingBullet _bullet;

    public override void Activate()
    {
        if (_bullet == null || !_bullet.isActiveAndEnabled)
        {
            PlayerController player = SkillManager.Instance.Player;
            if (player != null)
            {
                _bullet = (RotatingBullet)BulletManager.Instance.GetBullet(BulletManager.BulletType.RotatingBullet);
                _bullet.transform.parent = player.transform;
                _bullet.transform.position = Vector3.zero;
                _bullet.SetPlayer(player);
            }
        }
    }
}
