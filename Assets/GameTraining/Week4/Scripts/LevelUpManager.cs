using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    [SerializeField] private Skill[] allSkills;
    [SerializeField] private GameObject chooseSkillPanel;
    [SerializeField] private Button[] skillButtons;
    [SerializeField] private Player player;
    [SerializeField] private Image expBar;
    [SerializeField] private TextMeshProUGUI lvText;
    private int level = 1;
    private int currentEXP = 0;
    private int maxEXP = 10;

    #region Singleton
    private static LevelUpManager instance;

    public static LevelUpManager Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    public void AddExp(int exp)
    {
        currentEXP += exp;
        expBar.fillAmount = (float)currentEXP / maxEXP;
        if (currentEXP >= maxEXP)
        {
            LevelUp();
            GenSkill();
        }
    }

    public void LevelUp()
    {
        currentEXP -= maxEXP;
        level++;
        lvText.text = level.ToString();
        expBar.fillAmount = (float)currentEXP / maxEXP;
    }

    public void GenSkill()
    {
        // Pause game để chọn skill
        Time.timeScale = 0;

        chooseSkillPanel.SetActive(true);
        List<Skill> randomSkills = GetRandomSkills(skillButtons.Length);

        for (int i = 0; i < skillButtons.Length; i++)
        {
            Skill skill = randomSkills[i];
            skillButtons[i].transform.Find("Name").GetComponentInChildren<TextMeshProUGUI>().text = skill.skillName;
            skillButtons[i].transform.Find("Image").GetComponentInChildren<Image>().sprite = skill.icon;

            // Clear existing listeners and add the new listener
            skillButtons[i].onClick.RemoveAllListeners();
            skillButtons[i].onClick.AddListener(() =>
            {
                ChooseSkill(skill);
            });
        }
    }

    private List<Skill> GetRandomSkills(int number)
    {
        List<Skill> skills = new List<Skill>();

        for (int i = 0; i < number; i++)
        {
            Skill randomSkill;

            do
            {
                randomSkill = allSkills[Random.Range(0, allSkills.Length)];
            }
            while (skills.Contains(randomSkill));

            skills.Add(randomSkill);
        }

        return skills;
    }

    private void ChooseSkill(Skill skill)
    {
        player.AddSkill(skill);

        // Deactivate panel sau khi chọn xong skill
        chooseSkillPanel.SetActive(false);

        // PlayGame
        Time.timeScale = 1;
        EnemyManager.Instance.destroyAngel();
    }
}
