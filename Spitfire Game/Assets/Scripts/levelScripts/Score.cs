using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text ScoreTextRef;

    [SerializeField] int scoreAdd = 0;

    private static Score _instance;

    public static Score Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Score>();
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
        //Debug.Log("score added");
        scoreAdd++;
        Setup(scoreAdd);
    }
    void Setup(int scoreValue)
    {
        gameObject.SetActive(true);
        ScoreTextRef.text = "Score : " + scoreValue.ToString();
    }
}
