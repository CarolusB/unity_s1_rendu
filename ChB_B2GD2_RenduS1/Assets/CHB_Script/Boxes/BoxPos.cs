using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPos : MonoBehaviour
{
    public GameObject[] boxes = new GameObject[48];
    public bool[] boxHere = new bool[48];
    void Start()
    {
        for (int i = 1; i<48; i++)
        {
            boxHere[i] = false;
            boxes[i].GetComponent<SpriteRenderer>().enabled = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
