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

    private bool timeFrozen = false;

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
                if (breakSprites[i].enabled && !timeFrozen)
                {
                    
                    StartCoroutine(DelayedTickOff(0.4f, i));
                }
            }
        }
        else
        {
            sceneSwitcher.ToGameOver();
        }

        Debug.Log("Nb of misses: " + missCount);
    }

    
    
    IEnumerator DelayedTickOff(float delay, int b)
    {
        timeFrozen = true;
        Time.timeScale = 0f;
        missFaces[missCount].SetActive(true);
        yield return new WaitForSecondsRealtime(delay);
        breakSprites[b].enabled = false;

        missCount++;
        scorePersistent.TickUpMisses();

        spawnComponent.BoxHasBroken();
        Time.timeScale = 1f;
        timeFrozen = false;
    }


}
