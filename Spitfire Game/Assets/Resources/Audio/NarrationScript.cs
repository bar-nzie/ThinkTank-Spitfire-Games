using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class NarrationScript : MonoBehaviour
{

    [SerializeField] AudioSource[] tutorial;
    [SerializeField] AudioSource[] narration;

    [SerializeField] private List<int> pauseAfterClips = new List<int>();

    [HideInInspector] public bool tutorialPlaying = false;
    [HideInInspector] public bool waitForPlayerAction = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayTutorialAndThenFacts());
    }

    private IEnumerator PlayerTutorial()
    {
        tutorialPlaying = true;
        for (int i = 0; i < tutorial.Length; i++)
        {
            tutorial[i].Play();
            yield return new WaitUntil(() => !tutorial[i].isPlaying);

            //Check if need to wait for the player before playing next clip
            if (pauseAfterClips.Contains(i))
            {
                waitForPlayerAction = true;
                yield return new WaitUntil(() => waitForPlayerAction == false);
            }
        }
        tutorialPlaying = false;
    }

    public void PlayerCompletedAction()
    {
        waitForPlayerAction = false;
    }

    private IEnumerator PlayMyFacts()
    {

        foreach (AudioSource audio in narration)
        {
            audio.Play();
            yield return new WaitUntil(() => !audio.isPlaying);
        }
    }

    private IEnumerator PlayTutorialAndThenFacts()
    {
        yield return StartCoroutine(PlayerTutorial());
        yield return StartCoroutine(PlayMyFacts());
    }
}
