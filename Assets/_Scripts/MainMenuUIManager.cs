using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OpenHowToPlayPanel()
    {
        
    }


    public void OpenSettingPanel()
    {

    }
    public void OpenExitGamePanel()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
