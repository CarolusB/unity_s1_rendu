using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Scene Switcher", menuName = "ScriptObjects/Scene Switcher")]
public class SceneSwitcher : ScriptableObject
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void ToGameOver()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
