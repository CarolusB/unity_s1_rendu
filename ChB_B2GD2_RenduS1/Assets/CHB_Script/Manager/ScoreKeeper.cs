using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public GameObject[] truck = new GameObject[10];
    private SpriteRenderer[] inTruckSprites = new SpriteRenderer[10];
    private int slotToFill = 0;
    public GameObject boxPosKeeper;
    private BoxPos boxArray;
    private SpriteRenderer droppingBox;
    // Start is called before the first frame update
    void Start()
    {
        boxArray = boxPosKeeper.GetComponent<BoxPos>();
        droppingBox = boxArray.boxes[48].GetComponent<SpriteRenderer>();

        for (int i = 0; i < 10; i++)
        {
            inTruckSprites[i] = truck[i].GetComponent<SpriteRenderer>();
            inTruckSprites[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (droppingBox.enabled)
        {
            DoDelay();

            if (slotToFill < 9)
            {
                droppingBox.enabled = false;
                inTruckSprites[slotToFill].enabled = true;
                //Tick up score
                slotToFill++;
            }
            else
            {
                //Tick up score
                //Load rest scene
            }
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
