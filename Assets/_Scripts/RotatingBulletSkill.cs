using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBulletSkill : BaseSkill
{
    public RotatingBulletSkill() : base("RotatingBullet") { }

    private RotatingBullet _bullet;

    public override void ActivateSkill()
    {
        if (_bullet == null || !_bullet.isActiveAndEnabled)
        {
            PlayerController player = SkillManager.instance.player;
            if (player != null)
            {
                _bullet = (RotatingBullet)BulletPooling.Instance.GetBullet(BulletType.RotatingBullet);
                _bullet.transform.parent = player.transform;
                _bullet.transform.position = Vector3.zero;
            }
        }
    }
}
