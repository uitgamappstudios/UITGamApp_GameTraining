using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingBullet : PlayerBullet
{
    private GameObject target;

    public void SetTarget(GameObject target)
    {
        this.target = target;
        SetDirection(target.transform.position - transform.position);
    }

    protected override void Update()
    {
        if (target != null)
        {
            SetDirection(target.transform.position - transform.position);
        }

        // Hướng viên đạn bay theo hướng mục tiêu
        base.Update();
    }
    protected override void Destroy()
    {
        BulletManager.Instance.ReturnBullet(this, BulletManager.BulletType.TracingBullet);
    }
}
