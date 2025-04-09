using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text ScoreTextRef;
    [SerializeField] Image ScoreImageRef;

    [SerializeField] Image BronzeImageRef;
    [SerializeField] Image SilverImageRef;
    [SerializeField] Image GoldImageRef;

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


        if (scoreValue >= 10)
        {
            SilverImageRef.gameObject.SetActive(true);
            BronzeImageRef.gameObject.SetActive(false);
        }
        if (scoreValue >= 20)
        {
            GoldImageRef.gameObject.SetActive(true);
            SilverImageRef.gameObject.SetActive(false);
        }
        
    }
}
