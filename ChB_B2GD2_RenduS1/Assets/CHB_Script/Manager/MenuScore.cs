using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour
{
    public Score scorePersitent;
    public GameObject scoreCounter;
    protected Text scoreText;
    protected int scoreToDisplay;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        scoreText = scoreCounter.GetComponent<Text>();
        Debug.Log("Can touch score");
    }

    protected virtual void Update()
    {
        scoreToDisplay = scorePersitent.DisplayScore();
        scoreText.text = scoreToDisplay.ToString();
        Debug.Log("Score is: " + scoreText.text);
    }
}
