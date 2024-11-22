using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    protected Rigidbody2D rb;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    [SerializeField] protected GameObject target;

    virtual protected void Move(Vector2 direction) 
    {
        rb.velocity = direction.normalized * speed;
    }

    virtual public void BulletInit(Vector2 spawnPosition, Vector2 shootDirection) 
    {
        transform.position = spawnPosition;
        Move(shootDirection);
    }

    virtual public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<BaseEnemy>(out BaseEnemy enemy))
        {
            enemy.ModifyHealth(damage);
            BulletManager.Instance.ReleaseBullet(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BaseEnemy>(out BaseEnemy enemy))
        {
            enemy.ModifyHealth(damage);
            BulletManager.Instance.ReleaseBullet(this);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    virtual protected void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
}
