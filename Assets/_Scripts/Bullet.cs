using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    public float speed;

    public float damage;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            // tru mau Enemy
            EnemyController enemy1 =  collision.GetComponent<EnemyController>();
            if (enemy1 != null)
            {
                enemy1.ModifyHealth(-damage);
            }
            else
            {
                Enemy2Controller enemy2 = collision.GetComponent<Enemy2Controller>();
                if (enemy2 != null)
                {
                    enemy2.ModifyHealth(-damage);
                }
                else collision.GetComponent<Enemy3Controller>().ModifyHealth(-damage);
            }
            Destroy(gameObject);
        }

    }
}
