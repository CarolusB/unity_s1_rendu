using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    [Range(0, 42)]
    private int iD;
    public bool needPickUp;
    public GameObject breakFrame;
    private SpriteRenderer breakSprite;
    public GameObject boxPosKeeper;
    private BoxPos boxArray;
    private SpriteRenderer spriteOfNext;
    private SpriteRenderer spriteOfCurrent;
    public float trolleySpeed;
    private bool received = false;

    void Start()
    {
        boxArray = boxPosKeeper.GetComponent<BoxPos>();
        spriteOfNext = boxArray.boxes[iD + 1].GetComponent<SpriteRenderer>();
        spriteOfCurrent = gameObject.GetComponent<SpriteRenderer>();
        breakSprite = breakFrame.GetComponent<SpriteRenderer>();
        breakSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteOfCurrent.enabled)
        {
            if (needPickUp == true)
            {
                //Character makes transit or the box breaks
                StartCoroutine(OnEdge(trolleySpeed));

                if (received == true)
                {
                    StartCoroutine(NormalStep(0.2f));
                }
            }
            else
            {
                //Proceed to light next box frame
                StartCoroutine(NormalStep(trolleySpeed));
            }
        }
    }

    IEnumerator NormalStep(float delay)
    {
        yield return new WaitForSeconds(delay);

        spriteOfNext.enabled = true;
        boxArray.boxHere[iD + 1] = true;

        spriteOfCurrent.enabled = false;
        boxArray.boxHere[iD] = false;
    }

    IEnumerator OnEdge(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (received == false)
        {
            breakSprite.enabled = true;
            spriteOfCurrent.enabled = false;
        }
    }

    public void SetReceived(bool check)
    {
        received = check;
    }
}
