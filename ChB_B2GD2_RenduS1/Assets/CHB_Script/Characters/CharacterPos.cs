using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPos : MonoBehaviour
{
    public GameObject[] characterPos = new GameObject[3];
    [SerializeField]
    [Range(0, 2)]
    private int startPos;
    private int currentPos;

    [SerializeField]
    private KeyCode characUp;
    [SerializeField]
    private KeyCode characDown;

    void Start()
    {
        for (int i = 0; i<3; i++)
        {
            characterPos[i].SetActive(false);

            if (i == startPos)
            {
                characterPos[i].SetActive(true);
            }
        }

        currentPos = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(characUp) && currentPos < 2)
        {
            characterPos[currentPos + 1].SetActive(true);
            characterPos[currentPos].SetActive(false);

            currentPos++;
        }
        else if (Input.GetKeyDown(characDown) && currentPos > 0)
        {
            characterPos[currentPos - 1].SetActive(true);
            characterPos[currentPos].SetActive(false);

            currentPos--;
        }
    }
}
