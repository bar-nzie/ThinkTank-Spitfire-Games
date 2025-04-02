using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TakeDamage : MonoBehaviour
{
    /*    ScoreUpdateTestScript score;*/

    private Renderer rend;
    private Color originalColour;
    public GameObject explosionPrefab;
    public int Health;
    private void Awake()
    {
/*        score = GetComponent<ScoreUpdateTestScript>();*/
        rend = GetComponent<Renderer>();
        originalColour = rend.material.color;
    }
    public void takeDamage()
    {
        Health -= 1;
        if (Health <= 0)
        {
            ScoreUpdateTestScript.Instance.scoreIncreaser();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        StartCoroutine(FlashEffect());
    }

    IEnumerator FlashEffect()
    {
        rend.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = originalColour;
    }
}
