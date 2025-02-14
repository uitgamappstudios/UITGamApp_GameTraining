using System.Net.Http.Headers;
using UnityEngine;

public class RocketBullet : BaseBullet
{
    [SerializeField] private float radius;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private LayerMask targetLayer;

    public void RotateTowardsTarget()
    {
        Vector2 direction = (Vector2) target.transform.position - (Vector2) this.transform.position;

        // Đối với góc quay mục tiêu (tham số thứ 2), ta quay thêm 1 góc 90 độ theo chiều kim đồng hồ để transform.up của đạn hướng tới target
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90), rotateSpeed * Time.deltaTime);
    }

    public override void BulletInit(Vector2 spawnPosition, Vector2 shootDirection)
    {
        base.BulletInit(spawnPosition, shootDirection);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg - 90);
    }

    private void CheckTarget()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask(LayerMask.LayerToName((int)Mathf.Log(targetLayer.value, 2))));
        if (col != null) 
            target = col.gameObject;
    }

    public void Update()
    {
        Move(transform.up);
        
        CheckTarget();
        if (!target) return;
        
        RotateTowardsTarget();
    }

    private void OnDrawGizmos()
    {
        // Vẽ vùng biên định vị của đạn trong tab Scene
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        if (collision.collider.gameObject.layer == (int)Mathf.Log(targetLayer.value, 2))
            KillBullet();
    }
}
