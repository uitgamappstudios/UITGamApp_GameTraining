using UnityEngine;

public class BaseBullet : PooledObject
{
    protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    public GameObject target;

    virtual protected void Move(Vector2 direction) 
    {
        rb.velocity = direction.normalized * speed;
    }

    virtual public void BulletInit(Vector2 spawnPosition, Vector2 shootDirection) 
    {
        transform.position = spawnPosition;
        Move(shootDirection);
    }

    virtual protected void OnCollisionEnter2D(Collision2D collision) 
    {
        OnCollision(collision.collider.GetComponent<BaseEnemy>());
    }

    virtual protected void OnTriggerEnter2D(Collider2D collision) 
    {
        Debug.Log(collision.name);
        OnCollision(collision.GetComponent<BaseEnemy>());
    }

    virtual protected void OnCollision(BaseEnemy enemy)
    {
        if (enemy == null) return;
        enemy.ModifyHealth(-damage);
    }

    virtual protected void KillBullet()
    {
        BulletManager.Instance.ReleaseBullet(this);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    virtual protected void Start() { }
}
