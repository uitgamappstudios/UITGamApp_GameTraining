using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skills/Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public string skillDescription;
    public Sprite icon;

    public virtual void ApplySkill(GameObject player)
    {
        Debug.Log("Apply " + skillName);
    }    
}
