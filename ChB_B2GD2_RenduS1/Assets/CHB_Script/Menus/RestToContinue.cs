﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestToContinue : MonoBehaviour
{
    public SceneSwitcher sceneSwitcher;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            sceneSwitcher.StartGame();
        }
    }
}
