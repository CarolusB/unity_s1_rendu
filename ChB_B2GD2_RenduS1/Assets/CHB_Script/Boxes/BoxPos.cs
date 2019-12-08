using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPos : MonoBehaviour
{
    public GameObject[] boxes = new GameObject[43];
    public bool[] boxHere = new bool[43];
    void Start()
    {
        for (int i = 0; i<44; i++)
        {
            boxHere[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
