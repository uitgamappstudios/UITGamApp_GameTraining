using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    public float speed;

    //Thiet lap huong bay cua vien dan
    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    void Update()
    {
        // Di chuyển viên đạn theo hướng đã được thiết lập
        transform.position += direction * speed * Time.deltaTime;
    }
}
