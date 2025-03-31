using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : MonoBehaviour
{
    public string skillName;

    public BaseSkill(string skillName)
    {
        this.skillName = skillName;
    }

    public virtual void ActivateSkill()
    {
        Debug.Log("Skill Activated: " + skillName);
    }
}
