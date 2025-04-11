using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public PlayerController player;
    private Dictionary<string, SkillSO> skills = new Dictionary<string, SkillSO>();
    
    public List<SkillSO> allSkills = new List<SkillSO>(); //Danh sach tat ca skill
     
    public SkillSO[] randomSkills = new SkillSO[3]; //Danh sach 3 skill chon ra

    public float maxHealth; //Tao bien luu maxhealth hay vi lay tu player do luc chuyen scene player co the null

    public static SkillManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        /*AddSkill(new MultishotSkill());
        AddSkill(new TracingBulletSkill());
        AddSkill(new RotatingBulletSkill());*/

        //Thiet lap mau toi da cua player khi vua bat dau game
        maxHealth = player.playerConfig.maxHealth;
    }

    private void Update()
    {
        if(player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateSkill("MultishotSkill");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ActivateSkill("TracingBulletSkill");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ActivateSkill("RotatingBulletSkill");
        }
    }

    public void AddSkill(SkillSO skill)
    {
        if (!skills.ContainsKey(skill.skillName))
        {
            skills.Add(skill.skillName, skill);
        }
    }

    public void ActivateSkill(string skillName)
    {
        if (skills.ContainsKey(skillName))
        {
            skills[skillName].ActivateSkill();
        }
    }

    //Lay ra 3 skill ngau nhien trong kho skill
    public void TakeRandomSkill()
    {
        randomSkills[0] = allSkills[Random.Range(0, allSkills.Count)];
        randomSkills[1] = allSkills[Random.Range(0, allSkills.Count)];
        randomSkills[2] = allSkills[Random.Range(0, allSkills.Count)];
    }

    //Them skill duoc chon vao dictionary
    public void ChooseSkill(int i)
    {
        AddSkill(randomSkills[i]);
    }
}
