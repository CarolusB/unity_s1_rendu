using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFrame : MonoBehaviour
{
    public GameObject pickUpFrame_1;
    public GameObject pickUpFrame_2;

    private void OnEnable()
    {
        pickUpFrame_2.SetActive(false);
        pickUpFrame_1.SetActive(true);
    }

}
