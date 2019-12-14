using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Scene Switcher", menuName = "ScriptObjects/Scene Switcher")]
public class SceneSwitcher : ScriptableObject
{
    public void StartGame()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
    public void ToGameOver()
    {
        SceneManager.LoadScene(sceneBuildIndex:4);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex:0);
    }

    public void Rest()
    {
        SceneManager.LoadScene(sceneBuildIndex:3);
    }

    public void FullFrameLit()
    {
        SceneManager.LoadScene(sceneBuildIndex:2);
    }
}
