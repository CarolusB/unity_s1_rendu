using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Score", menuName = "ScriptObjects/Score")]
public class Score : ScriptableObject
{
    private static int score = 0;

    public void TickUpScore(int points)
    {
        score += points;
    }

    public int DisplayScore()
    {
        return score;
    }
}
