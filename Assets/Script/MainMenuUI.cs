using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void StartButtonPressed()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}
