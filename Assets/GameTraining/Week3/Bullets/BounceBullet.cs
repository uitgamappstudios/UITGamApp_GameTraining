using UnityEngine;

public class BounceBullet : BaseBullet
{
    private Vector2 prevVel;
    private float elapsedTime;
    [SerializeField] private float existTime;

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        elapsedTime = 0;
    }

    public override void BulletInit(Vector2 spawnPosition, Vector2 shootDirection)
    {
        base.BulletInit(spawnPosition, shootDirection);
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
    override public void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        rb.velocity = Vector2.Reflect(prevVel.normalized, collision.contacts[0].normal) * speed;
    }
}
