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
    public GameObject boxPosKeeper;
    private BoxPos boxArray;
    public bool isReceived;

    void Start()
    {
        boxArray = boxPosKeeper.GetComponent<BoxPos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled)
        {
            if (needPickUp)
            {
                //Character makes transit or the box breaks
            }
            else
            {
                StartCoroutine(NormalStep(3f));
            }
        }
    }

    IEnumerator NormalStep(float delay)
    {
        yield return new WaitForSeconds(delay);

        boxArray.boxes[iD + 1].GetComponent<SpriteRenderer>().enabled = true;
        boxArray.boxHere[iD + 1] = true;

        boxArray.boxes[iD].GetComponent<SpriteRenderer>().enabled = false;
        boxArray.boxHere[iD] = false;
    }
}
