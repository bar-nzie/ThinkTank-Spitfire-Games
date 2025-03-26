using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdateTestScript : MonoBehaviour
{
    public Score score;
    public int scoreAdd = 0;

    void scoreIncreaser()
    {
        scoreAdd++;
        score.Setup(scoreAdd);
    }
}
