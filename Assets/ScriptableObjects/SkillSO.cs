using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSO : ScriptableObject
{
    public string skillName;
    public float cooldownTime;
    public float activateTime;
    public Sprite skillIcon;
    public bool loop = true;

    public virtual void ActivateSkill() { }
}
