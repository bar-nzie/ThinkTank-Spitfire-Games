using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text ScoreTextRef;

    [SerializeField] Image BronzeImageRef;
    [SerializeField] Image SilverImageRef;
    [SerializeField] Image GoldImageRef;

    int scoreAdd = 0;

    [SerializeField] int scoreSilver = 15;
    [SerializeField] int scoreGold = 30;

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
        medalSetup(scoreAdd);
    }

    public void scoreIncreaser()
    {
        //Debug.Log("score added");
        scoreAdd++;
        scoreSetup(scoreAdd);
    }
    void scoreSetup(int scoreValue)
    {
        gameObject.SetActive(true);
        ScoreTextRef.text = scoreValue.ToString();
    }

    void medalSetup(int scoreValue)
    {
        BronzeImageRef.gameObject.SetActive(true);
        SilverImageRef.gameObject.SetActive(false);
        GoldImageRef.gameObject.SetActive(false);


        if (scoreValue >= scoreSilver)
        {
            SilverImageRef.gameObject.SetActive(true);
            BronzeImageRef.gameObject.SetActive(false);
        }
        if (scoreValue >= scoreGold)
        {
            GoldImageRef.gameObject.SetActive(true);
            SilverImageRef.gameObject.SetActive(false);
        }
        
    }
}
