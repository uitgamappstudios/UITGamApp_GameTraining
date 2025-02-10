using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MultiShot", menuName = "Skills/Multi Shot")]
public class MultiShotSkill : Skill
{
    public override void ApplySkill(GameObject player)
    {
        base.ApplySkill(player);

        player.GetComponent<Player>().AddShot(1);
    }
}
