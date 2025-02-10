using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BaseBullet
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

//        Debug.Log(collision.gameObject.tag);

        // Biến mất khi va chạm
        if (!collision.gameObject.CompareTag("Player"))
            BulletManager.Instance.ReleaseBullet(this);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Debug.Log(collision.gameObject.tag);

        // Biến mất khi va chạm
        if (!collision.gameObject.CompareTag("Player"))
            BulletManager.Instance.ReleaseBullet(this);
    }
}
