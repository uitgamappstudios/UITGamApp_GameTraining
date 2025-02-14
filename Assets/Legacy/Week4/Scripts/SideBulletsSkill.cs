using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SideBullets", menuName = "Skills/Side Bullets")]
public class SideBulletsSkill : Skill
{
    public override void ApplySkill(GameObject player)
    {
        base.ApplySkill(player);

        player.GetComponent<Player>().ActiveSideBullet();
    }
}
