using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BounceBullet : BaseBullet
{
    private Vector2 prevVel;

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        rb.velocity = Vector2.up;
    }

    private void Update()
    {
        // Lưu lại vận tốc của đạn nhằm sử dụng cho frame sau
        prevVel = rb.velocity;
        Move(rb.velocity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.Reflect(prevVel.normalized, collision.contacts[0].normal) * speed;
    }
}
