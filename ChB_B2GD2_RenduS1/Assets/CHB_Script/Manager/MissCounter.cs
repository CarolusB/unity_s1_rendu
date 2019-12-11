using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCounter : MonoBehaviour
{
    public GameObject[] breakFrames = new GameObject[3];
    private SpriteRenderer[] breakSprites = new SpriteRenderer[3];

    public GameObject[] missFaces = new GameObject[3];
    private int missCount = 0;
    //private bool coRoutineOn = false;

    public GameObject boxSpawner;
    private BoxSpawn spawnComponent;

    public SceneSwitcher sceneSwitcher;

    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            breakSprites[i] = breakFrames[i].GetComponent<SpriteRenderer>();
            breakSprites[i].enabled = true;
            missFaces[i].SetActive(true);
        }
    }
    void Start()
    {
        spawnComponent = boxSpawner.GetComponent<BoxSpawn>();

        for (int i = 0; i < 3; i++)
        {
            breakSprites[i].enabled = false;
            missFaces[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (missCount < 3)
        {
            for (int i = 0; i < 3; i++)
            {
                if (breakSprites[i].enabled)
                {
                    missFaces[missCount].SetActive(true);
                    DoDelay();
                    breakSprites[i].enabled = false;
                    missCount++;
                    spawnComponent.BoxHasBroken();

                }
            }
        }
        else
        {
            sceneSwitcher.ToGameOver();
        }

        Debug.Log("Nb of misses: " + missCount);
    }

    
    void DoDelay()
    {
        StartCoroutine(DelayedTickOff(0.4f));
    }
    IEnumerator DelayedTickOff(float delay)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f;
    }


}
