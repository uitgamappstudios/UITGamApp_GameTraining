using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public PlayerController player;
    private Dictionary<string, BaseSkill> skills = new Dictionary<string, BaseSkill>();
    
    public List<BaseSkill> allSkills = new List<BaseSkill>(); //Danh sach tat ca skill
     
    public BaseSkill[] randomSkills = new BaseSkill[3]; //Danh sach 3 skill chon ra

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

        //Them toan bo skill vao danh sach
        allSkills.Add(new MultishotSkill());
        allSkills.Add(new TracingBulletSkill());
        allSkills.Add(new RotatingBulletSkill());
    }

    private void Update()
    {
        if(player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateSkill("Multishot");
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ActivateSkill("TracingBullet");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ActivateSkill("RotatingBullet");
        }
    }

    public void AddSkill(BaseSkill skill)
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
        randomSkills[0] = allSkills[Random.Range(0, 3)];
        randomSkills[1] = allSkills[Random.Range(0, 3)];
        randomSkills[2] = allSkills[Random.Range(0, 3)];
    }

    //Them skill duoc chon vao dictionary
    public void ChooseSkill(int i)
    {
        AddSkill(randomSkills[i]);
    }
}
