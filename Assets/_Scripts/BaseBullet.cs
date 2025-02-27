using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    protected Vector3 direction;
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction.normalized;
    }
    protected virtual void Update()
    {
        // Di chuyển viên đạn theo hướng đã được thiết lập
        transform.position += direction * speed * Time.deltaTime;
    }
}
