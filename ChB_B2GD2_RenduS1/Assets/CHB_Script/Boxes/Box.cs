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
    public GameObject characPos;
    private CharacterFrame characFrame;
    private bool coRoutineOn = false;

    void Start()
    {
        boxArray = boxPosKeeper.GetComponent<BoxPos>();
        spriteOfNext = boxArray.boxes[iD + 1].GetComponent<SpriteRenderer>();
        spriteOfCurrent = gameObject.GetComponent<SpriteRenderer>();

        breakSprite = breakFrame.GetComponent<SpriteRenderer>();
        breakSprite.enabled = false;

        characFrame = characPos.GetComponent<CharacterFrame>();

    }

    // Update is called once per frame
    void Update()
    {
        if (spriteOfCurrent.enabled && !coRoutineOn)
        {
            if (needPickUp)
            {
                //Character makes transit or the box breaks
                StartCoroutine(OnEdge(trolleySpeed));

                if (received)
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
        coRoutineOn = true;
        yield return new WaitForSeconds(delay);

        spriteOfNext.enabled = true;
        boxArray.boxHere[iD + 1] = true;

        spriteOfCurrent.enabled = false;
        boxArray.boxHere[iD] = false;

        if (needPickUp)
        {
            spriteOfCurrent.enabled = false;
            characFrame.pickUpFrame_2.SetActive(true);
            characFrame.pickUpFrame_1.SetActive(false);

            yield return new WaitForSeconds(0.2f);

            characFrame.pickUpFrame_1.SetActive(true);
            characFrame.pickUpFrame_2.SetActive(false);

        }

        coRoutineOn = false;
    }

    IEnumerator OnEdge(float delay)
    {
        coRoutineOn = true;

        yield return new WaitForSeconds(delay);

        if (!received)
        {
            breakSprite.enabled = true;
            spriteOfCurrent.enabled = false;
        }

        coRoutineOn = false;
    }

    public void SetReceived(bool check)
    {
        received = check;
    }
}
