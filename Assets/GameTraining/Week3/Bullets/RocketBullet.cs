using UnityEngine;

public class RocketBullet : BaseBullet
{
    [SerializeField] private float radius;
    [SerializeField] private float rotateSpeed;
    

    public void RotateTowardsTarget()
    {
        Vector2 direction = (Vector2) target.transform.position - (Vector2) this.transform.position;

        // Đối với góc quay mục tiêu (tham số thứ 2), ta quay thêm 1 góc 90 độ theo chiều kim đồng hồ để transform.up của đạn hướng tới target
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90), rotateSpeed * Time.deltaTime);
    }

    protected override void Start()
    {
        base.Start();
    }

    public void Update()
    {
        Move(transform.up);
        if (Vector2.Distance(target.transform.position, this.transform.position) < radius )
        {
            RotateTowardsTarget();
        }
    }

    private void OnDrawGizmos()
    {
        // Vẽ vùng biên định vị của đạn trong tab Scene
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
