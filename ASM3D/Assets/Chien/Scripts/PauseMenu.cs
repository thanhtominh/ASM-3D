using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HomeButton()
    {
        Debug.Log("Home Button Pressed");
        SceneManager.LoadScene(0);
    }

    public void ResumeButton()
    {
        Debug.Log("Resume Button Pressed");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

}
