using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skills/Poison Circular")]
public class PoisonCircleSkill : Skill
{
    [SerializeField] private CircularBullet_Copy circularBullet;

    public override void ApplySkill(GameObject player)
    {
        base.ApplySkill(player);

        float startAngle = 0f;
        float angleOffset = 180f;  // Góc giữa 2 viên đạn

        // Spawn 2 circularBullet
        for (int i = 0; i < 2; i++)
        {
            var bulletSpawn = Instantiate(circularBullet, player.transform);
            float angle = startAngle + (angleOffset * i);
            bulletSpawn.SetAngle(angle);
        } 
    }
}
