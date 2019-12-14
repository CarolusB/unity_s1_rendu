using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FullLitTransition : MonoBehaviour
{
    public SceneSwitcher sceneSwitcher;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitBeforeStart());
    }

    IEnumerator WaitBeforeStart()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1f;
        sceneSwitcher.StartGame();
    }
}
