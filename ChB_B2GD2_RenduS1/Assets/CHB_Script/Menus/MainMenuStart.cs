using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    public SceneSwitcher sceneSwitcher;
    public Score scorePersistent;

    private void Start()
    {
        scorePersistent.ResMisses();
        scorePersistent.ResScores();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            sceneSwitcher.FullFrameLit();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
