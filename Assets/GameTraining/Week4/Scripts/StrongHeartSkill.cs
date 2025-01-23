using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Strong Heart")]
public class StrongHeartSkill : Skill
{
    public float amount;

    public override void ApplySkill(GameObject player)
    {
        base.ApplySkill(player);

        player.GetComponent<Player>().IncreaseMaxHealth(amount);
    }
}
