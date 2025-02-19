using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
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
            OnCollision(collision.GetComponent<PlayerController>());
            Destroy(gameObject);
        }
    }
    private void OnCollision(PlayerController player)
    {
        if (player == null) return;
        player.ModifyHealth(-damage);
    }
}
