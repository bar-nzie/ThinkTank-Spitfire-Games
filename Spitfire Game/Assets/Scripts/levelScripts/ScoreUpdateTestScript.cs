using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdateTestScript : MonoBehaviour
{
    public Score score;
    public int scoreAdd = 0;

    private static ScoreUpdateTestScript _instance;

    public static ScoreUpdateTestScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreUpdateTestScript>();
            }
            return _instance;
        }
    }
    public void Update()
    {
        //scoreIncreaser();
    }

    public void scoreIncreaser()
    {
        Debug.Log("score added");
        scoreAdd++;
        score.Setup(scoreAdd);
    }
}
