using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    protected Vector3 direction;
    public BulletType bulletType;
    public BulletConfigs configs;
    private BulletConfig bulletConfig;

    public float speed => bulletConfig.speed;
    public float damage => bulletConfig.damage;

    public void InitConfig()
    {
        bulletConfig = configs.GetConfig(bulletType);
        if (bulletConfig == null)
            Debug.Log("Config not found");
    }

    private void Start()
    {
        InitConfig();
    }

    //Thiet lap huong bay cua vien dan
    public virtual void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        // Di chuyển viên đạn theo hướng đã được thiết lập
        transform.position += direction * speed * Time.deltaTime;
    }
}
