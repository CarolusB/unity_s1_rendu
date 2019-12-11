using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour
{
    public GameObject firstFrame;
    private SpriteRenderer firstSprite;

    private float timeBetwSpawn;

    private int boxesInPlay;

    private bool waitingToSpawn = false;
    void Start()
    {
        firstSprite = firstFrame.GetComponent<SpriteRenderer>();
        boxesInPlay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (boxesInPlay < 10 && !firstSprite.enabled && !waitingToSpawn)
        {
            if (boxesInPlay == 0)
            {
                StartCoroutine(SpawnAfter(1.8f));
            }
            else
            {
                timeBetwSpawn = Random.Range(9, 15);
                StartCoroutine(SpawnAfter(timeBetwSpawn));
            }
        }

        Debug.Log("Nb boxes on conveyor: " + boxesInPlay);
    }

    IEnumerator SpawnAfter(float delay)
    {
        waitingToSpawn = true;

        Debug.Log("Box " + (boxesInPlay + 1) + " coming in " + delay + " seconds");

        yield return new WaitForSeconds(delay);

        firstSprite.enabled = true;
        boxesInPlay++;
        waitingToSpawn = false;
    }

    public void BoxHasBroken()
    {
        boxesInPlay--;
    }
}
