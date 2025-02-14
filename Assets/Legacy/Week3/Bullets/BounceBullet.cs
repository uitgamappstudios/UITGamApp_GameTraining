using UnityEngine;

public class BounceBullet : BaseBullet
{
    private Vector2 prevVel;
    private float elapsedTime;
    [SerializeField] private float existTime;

    private void OnEnable()
    {
        elapsedTime = 0;
    }

    private void Update()
    {
        // Lưu lại vận tốc của đạn nhằm sử dụng cho frame sau
        prevVel = rb.velocity;
        Move(rb.velocity);

        elapsedTime += Time.deltaTime;
        if (elapsedTime > existTime)
        {
            BulletManager.Instance.ReleaseBullet(this);
        }
    }
    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        rb.velocity = Vector2.Reflect(prevVel.normalized, collision.contacts[0].normal) * speed;
    }
}
