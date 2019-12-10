using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPickup : MonoBehaviour
{
    public GameObject edgeBox;
    private Box boxState;
    private bool canPickUp = false;
    private SpriteRenderer edgeSprite;

    // Start is called before the first frame update
    void Start()
    {
        boxState = edgeBox.GetComponent<Box>();
        edgeSprite = boxState.CurrentSprite;

    }

    private void OnEnable()
    {
        canPickUp = true;
        boxState.SetReceived(true);
    }

    private void OnDisable()
    {
        canPickUp = false;
        boxState.SetReceived(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (canPickUp && edgeSprite.enabled)
        {
            boxState.SetReceived(true);
        }
    }
}
