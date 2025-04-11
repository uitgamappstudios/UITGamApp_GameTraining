using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MultishotSkill", menuName = "ScriptableObjects/MultishotSkillSO")]
public class MultishotSkillSO : SkillSO
{
    public int numberOfBullet = 3;

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
