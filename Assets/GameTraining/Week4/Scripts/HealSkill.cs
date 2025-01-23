using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Skills/Heal")]
public class HealSkill : Skill
{
    public float amount;

    public override void ApplySkill(GameObject player)
    {
        base.ApplySkill(player);

        player.GetComponent<Player>().Heal(amount);
    }
}
