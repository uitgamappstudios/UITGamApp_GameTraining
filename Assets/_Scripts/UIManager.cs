using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.ComponentModel;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
       
        else Destroy(gameObject);
    }
    #endregion

    public TextMeshProUGUI scoreText;
    public Slider healthbar;
    public GameObject panelLose;
    public GameObject nextLevelButton;

    public GameObject panelSkill;
    public TextMeshProUGUI skill1Text;
    public TextMeshProUGUI skill2Text;
    public TextMeshProUGUI skill3Text;

    public GameObject pausePanel;

    public void Start()
    {
        healthbar.maxValue = SkillManager.instance.maxHealth;
    }

    public void Update()
    {
        scoreText.SetText("Score: "+ GameManager.instance.GetScore().ToString());
        if(SkillManager.instance.player != null ) 
            healthbar.value = SkillManager.instance.player.currHealth;
    }

    public void Lose()
    {
        panelLose.SetActive(true);
    }

    public void Win()
    {
        ShowSkill();
        panelSkill.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        panelLose.SetActive(false);
    }

    public void NextRoom(string roomName)
    {
        SceneManager.LoadScene(roomName);
    }

    public void ShowSkill()
    {
        SkillManager.instance.TakeRandomSkill(); //Chon skill cho vao randomSkills

        //Hien thi ten cac skill trong 
        skill1Text.SetText(SkillManager.instance.randomSkills[0].skillName);
        skill2Text.SetText(SkillManager.instance.randomSkills[1].skillName);
        skill3Text.SetText(SkillManager.instance.randomSkills[2].skillName);

        panelSkill.SetActive(true);
    }

    public void ChooseSkill(int i )
    {
        SkillManager.instance.ChooseSkill(i);
        panelSkill.SetActive(false);
        nextLevelButton.SetActive(true);
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        
    }
    public void ClosePausePanel()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);

    }
    public void ExitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
    public void RestartGame()
    {
        PlayAgain();
        ClosePausePanel();
    }
}
