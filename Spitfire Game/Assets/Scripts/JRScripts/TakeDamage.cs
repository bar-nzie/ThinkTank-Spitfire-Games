using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TakeDamage : MonoBehaviour
{
/*    ScoreUpdateTestScript score;*/

    public int Health;
    private void Awake()
    {
/*        score = GetComponent<ScoreUpdateTestScript>();*/
    }
    public void takeDamage()
    {
        Health -= 1;
        if (Health <= 0)
        {
            ScoreUpdateTestScript.Instance.scoreIncreaser();
            Destroy(this.gameObject);
        }
    }
}
