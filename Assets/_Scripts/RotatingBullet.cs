using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBullet : PlayerBullet
{
    [SerializeField] private float radius; // Bán kính di chuyển của đạn

    private float currentAngle;
    private PlayerController player;

    public void SetPlayer(PlayerController player)
    {
        this.player = player;
    }

    protected override void Update()
    {
        // Di chuyển viên đạn theo vòng tròn xung quanh player
        if (player == null)
            return;

        currentAngle += speed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Sin(currentAngle), Mathf.Cos(currentAngle), 0) * radius;
        transform.position = player.transform.position + offset;
    }

    protected override void Destroy() { }
}
