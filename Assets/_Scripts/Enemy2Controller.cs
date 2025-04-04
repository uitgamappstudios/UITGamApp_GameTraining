using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : BaseEnemy
{

    public float shootCoolDown;
    public float timer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        timer = 0;
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

    public void Shoot()
    {
        Vector3 directionNormalized = (player.transform.position - transform.position).normalized;

        // Tạo viên đạn từ prefab
        var bullet = BulletPooling.Instance.GetBullet(BulletType.EnemyBullet);
        bullet.transform.position = transform.position;

        // Thiết lập hướng bay cho viên đạn
        bullet.SetDirection(directionNormalized);
    }
}
