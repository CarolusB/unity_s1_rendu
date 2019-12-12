using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Score", menuName = "ScriptObjects/Score")]
public class Score : ScriptableObject
{
    private static int score = 0;
    private static int missSaver = 0;

    public void TickUpScore(int points)
    {
        score += points;
    }

    public int DisplayScore()
    {
        return score;
    }

    public void TickUpMisses()
    {
        missSaver++;
    }

    public int GetMisses()
    {
        return missSaver;
    }

    public void ResScores()
    {
        score = 0;
    }
    public void ResMisses()
    {
        missSaver = 0;
    }
}
