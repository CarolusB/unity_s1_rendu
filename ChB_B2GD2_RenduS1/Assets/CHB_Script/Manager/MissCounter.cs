using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCounter : MonoBehaviour
{
    public GameObject[] breakFrames = new GameObject[3];
    private SpriteRenderer[] breakSprites = new SpriteRenderer[3];

    public GameObject[] missFaces = new GameObject[3];
    private int missCount;
    //private bool coRoutineOn = false;

    public GameObject boxSpawner;
    private BoxSpawn spawnComponent;

    public Score scorePersistent;
    public SceneSwitcher sceneSwitcher;

    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            breakSprites[i] = breakFrames[i].GetComponent<SpriteRenderer>();
            breakSprites[i].enabled = false;
            missFaces[i].SetActive(false);
        }
    }
    void Start()
    {
        spawnComponent = boxSpawner.GetComponent<BoxSpawn>();
        missCount = scorePersistent.GetMisses();

        if (missCount > 0)
        {
            for (int m = 0; m < missCount; missCount++)
            {
                missFaces[m].SetActive(true);
            }
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
                    scorePersistent.TickUpMisses();

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
