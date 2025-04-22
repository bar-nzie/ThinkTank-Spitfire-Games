using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationScript : MonoBehaviour
{

    [SerializeField] AudioSource[] narration;

    public bool factsArePlaying;

    // Start is called before the first frame update
    void Start()
    {
        factsArePlaying = true;
        StartCoroutine(PlayMyFacts());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlayMyFacts()
    {
        foreach (AudioSource audio in narration)
        {
            audio.Play();
            yield return new WaitUntil(() => !audio.isPlaying);
        }
        factsArePlaying = false;
    }
}
