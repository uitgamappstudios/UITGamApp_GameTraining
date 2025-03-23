using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        if (collision.CompareTag("Player"))
        {
            // tru mau Enemy
            collision.GetComponent<PlayerController>().ModifyHealth(-damage);
            Destroy(gameObject);
        }

    }
}
