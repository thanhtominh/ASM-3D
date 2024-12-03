using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Chien");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game exited!");
    }
}
