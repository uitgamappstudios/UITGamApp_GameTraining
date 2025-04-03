using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public TextMeshProUGUI scoreText;
    public Slider healthbar;
    public GameObject nextRoomButton;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        healthbar.maxValue = SkillManager.instance.player.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText(GameManager.instance.score.ToString());
        healthbar.value = SkillManager.instance.player.currHealth;
    }

    public void Win()
    {
        nextRoomButton.SetActive(true);
    }

    public void NextRoom(string roomName)
    {
        SceneManager.LoadScene(roomName);
    }
}
