using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : BaseEnemy
{

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
        timer += Time.deltaTime;
        if (player != null)
        {
            Move();
            if (timer > shootCoolDown)
            {
                Shoot();
                timer = 0;
            }
        }
    }
    public void Move()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        Vector3 velocity = direction.normalized * speed;
        this.transform.position += velocity * Time.deltaTime;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
    public void Shoot()
    {
        Vector3 directionNormalized = (player.transform.position - transform.position).normalized;

        // Tạo viên đạn từ prefab
        var bullet = BulletPooling.Instance.GetBullet(BulletType.EnemyBullet);
        bullet.transform.position = transform.position;

        // Thiết lập hướng bay cho viên đạn
        bullet.SetDirection(directionNormalized);
    }
    public void ModifyHealth(float health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
}
