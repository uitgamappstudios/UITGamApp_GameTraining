using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    public PlayerController Player => player;

    private Dictionary<string, BaseSkill> skills = new Dictionary<string, BaseSkill>();
    
    #region Singleton
    private static SkillManager _instance;
    public static SkillManager Instance => _instance;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    private void Start()
    {
        AddSkill(new MultiShotSkill());
    }

    private void Update()
    {
        UseSkill("MultiShot");
    }

    public void AddSkill(BaseSkill skill)
    {
        if (!skills.ContainsKey(skill.skillName))
        {
            skills.Add(skill.skillName, skill);
            Debug.Log($"Add {skill.skillName} skill");
        }
        else
        {
            Debug.LogWarning($"Skill {skill.skillName} already exists!");
        }
    }    

    public void UseSkill(string skillName)
    {
        if (!skills.ContainsKey(skillName))
        {
            Debug.LogWarning($"Skill {skillName} not found!");
            return;
        }

        skills[skillName].Activate();
    }    
}
