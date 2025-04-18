using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationScript : MonoBehaviour
{

    [SerializeField] AudioSource[] narration;

    // Start is called before the first frame update
    void Start()
    {
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
            yield return new WaitForSeconds(audio.clip.length);
        }
    }
}
