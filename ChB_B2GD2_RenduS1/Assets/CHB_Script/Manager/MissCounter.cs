using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCounter : MonoBehaviour
{
    public GameObject[] breakFrames = new GameObject[3];
    private SpriteRenderer[] breakSprites = new SpriteRenderer[3];

    public GameObject[] missFaces = new GameObject[3];
    private int missCount = 0;
    private bool coRoutineOn = false;

    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            breakSprites[i] = breakFrames[i].GetComponent<SpriteRenderer>();
            breakSprites[i].enabled = true;
        }
    }
    void Start()
    {
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

                    StartCoroutine(DelayedTickOff(1.2f));
                    breakSprites[i].enabled = false;
                    missCount++;

                }
            }
        }

        Debug.Log("Nb of misses: " + missCount);
    }

    IEnumerator DelayedTickOff(float delay)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f;
    }


}
