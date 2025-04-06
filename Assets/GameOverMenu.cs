using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    public GameObject GameOverMenuUI;

    public void GameOver()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
