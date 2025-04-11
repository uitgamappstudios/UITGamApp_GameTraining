using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealSkill", menuName = "ScriptableObjects/HealSkillSO")]
public class HealSkillSO : SkillSO
{
    public float healAmount = 5f;

    public override void ActivateSkill()
    {
        PlayerController player = SkillManager.instance.player;
        player.ModifyHealth(healAmount);
    }
}
