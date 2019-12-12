using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MenuScore
{
    public GameObject[] truck = new GameObject[10];
    private SpriteRenderer[] inTruckSprites = new SpriteRenderer[10];
    private int slotToFill = 0;
    public GameObject boxPosKeeper;
    private BoxPos boxArray;
    private SpriteRenderer droppingBox;
    private bool[] floorCanScore = new bool[5];

    public SceneSwitcher sceneSwitcher;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        boxArray = boxPosKeeper.GetComponent<BoxPos>();
        droppingBox = boxArray.boxes[48].GetComponent<SpriteRenderer>();

        for (int i = 0; i < 10; i++)
        {
            inTruckSprites[i] = truck[i].GetComponent<SpriteRenderer>();
            inTruckSprites[i].enabled = false;
        }

        for (int f = 0; f < 5; f++)
        {
            floorCanScore[f] = true;
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (droppingBox.enabled)
        {
            DoDelay();

            if (slotToFill < 9)
            {
                droppingBox.enabled = false;
                inTruckSprites[slotToFill].enabled = true;
                scorePersitent.TickUpScore(10);
                slotToFill++;
            }
            else
            {
                scorePersitent.TickUpScore(10);
                sceneSwitcher.Rest();
            }
        }

        //Plus opti de drag and drop les box de transition et leurs suivantes et faire appel à un for
        if (boxArray.boxHere[3] && floorCanScore[0])
        {
            scorePersitent.TickUpScore(1);
            floorCanScore[0] = false;
        }

        if (boxArray.boxHere[4] && !floorCanScore[0])
        {
            floorCanScore[0] = true;
        }

        if (boxArray.boxHere[12] && floorCanScore[1])
        {
            scorePersitent.TickUpScore(1);
            floorCanScore[1] = false;
        }

        if (boxArray.boxHere[13] && !floorCanScore[1])
        {
            floorCanScore[1] = true;
        }

        if (boxArray.boxHere[21] && floorCanScore[2])
        {
            scorePersitent.TickUpScore(1);
            floorCanScore[2] = false;
        }

        if (boxArray.boxHere[22] && !floorCanScore[2])
        {
            floorCanScore[2] = true;
        }

        if (boxArray.boxHere[30] && floorCanScore[3])
        {
            scorePersitent.TickUpScore(1);
            floorCanScore[3] = false;
        }

        if (boxArray.boxHere[31] && !floorCanScore[3])
        {
            floorCanScore[3] = true;
        }

        if (boxArray.boxHere[39] && floorCanScore[4])
        {
            scorePersitent.TickUpScore(1);
            floorCanScore[4] = false;
        }

        if (boxArray.boxHere[40] && !floorCanScore[4])
        {
            floorCanScore[4] = true;
        }
    }

    
    void DoDelay()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
    }
}
