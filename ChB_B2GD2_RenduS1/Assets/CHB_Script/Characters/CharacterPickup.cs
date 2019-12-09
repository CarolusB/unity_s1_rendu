using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPickup : MonoBehaviour
{
    public GameObject edgeBox;
    private Box boxState;

    // Start is called before the first frame update
    void Start()
    {
        boxState = edgeBox.GetComponent<Box>();
    }

    private void OnEnable()
    {
        boxState.SetReceived(true);
    }

    private void OnDisable()
    {
        boxState.SetReceived(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
