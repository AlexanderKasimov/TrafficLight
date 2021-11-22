using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void OnRestartClicked()
    {
        GameManager.instance.TogglePause(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }

    public void OnExitClicked()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnNextLevelClicked()
    {
        GameManager.instance.TogglePause(false);
        SceneManager.LoadScene(GameManager.instance.GetNextSceneName());
    }


}
