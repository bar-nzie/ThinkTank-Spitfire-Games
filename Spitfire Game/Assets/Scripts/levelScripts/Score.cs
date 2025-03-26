using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public void Setup(int scoreValue)
    {
        gameObject.SetActive(true);
        score.text = "Score : " + scoreValue.ToString();
    }
}
