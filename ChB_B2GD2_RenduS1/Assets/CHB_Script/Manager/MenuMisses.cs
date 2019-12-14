using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMisses : MonoBehaviour
{
    public Score scorePersistent;

    public GameObject[] missFaces = new GameObject[3];
    private int missCount;

    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            missFaces[i].SetActive(false);
        }
    }
    void Start()
    {
        missCount = scorePersistent.GetMisses();

        if (missCount > 0)
        {
            for (int m = 0; m < missCount; missCount++)
            {
                missFaces[m].SetActive(true);
            }
        }
    }

    
}
