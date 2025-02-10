using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class SkillItemUI : MonoBehaviour
{
    private Skill _skill;
    public Image imgSkillIcon;
    public TextMeshProUGUI txtSkillName;
    private System.Action<Skill> _onClickSkill;
    public void ParseData(Skill skill, System.Action<Skill> onClickSkill)
    {
        this._skill = skill;
        this._onClickSkill = onClickSkill;

        // Set image and name
        imgSkillIcon.sprite = _skill.icon;
        txtSkillName.text = _skill.skillName;
    }

    public void ClickSkill()
    {
        this._onClickSkill?.Invoke(this._skill);
    }
}
