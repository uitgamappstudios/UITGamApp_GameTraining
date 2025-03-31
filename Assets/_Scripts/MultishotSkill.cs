using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultishotSkill : BaseSkill
{
    private int numberOfBullet = 3;

    public MultishotSkill() : base("Multishot")
    {
    }

    public override void ActivateSkill()
    {
        PlayerController player = SkillManager.instance.player;

        if (player != null)
        {
            for (int i = 0; i < numberOfBullet; i++)
            {
                player.Shoot();
            }
        }

        Debug.Log("Skill Activated: " + skillName);
    }
}
