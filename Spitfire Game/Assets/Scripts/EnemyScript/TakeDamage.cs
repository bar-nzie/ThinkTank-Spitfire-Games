using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TakeDamage : MonoBehaviour
{
    private Renderer rend;
    private Color originalColour;

    public GameObject explosionPrefab;
    public int Health;
    private bool isDying = false;

    [SerializeField] AudioSource takeDamageSound;
    [SerializeField] AudioSource balloonPopSound;

    [SerializeField] float minPitch = 0.95f;
    [SerializeField] float maxPitch = 1.05f;

    //Pitch shift
    void PlayTakeDamageSound()
    {
        if (takeDamageSound != null)
        {
            takeDamageSound.pitch = Random.Range(minPitch, maxPitch);
            takeDamageSound.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource not assigned for TakeDamage sound!");
        }
    }
    void PlayBalloonPopSound()
    {
        if (balloonPopSound != null)
        {
            balloonPopSound.pitch = Random.Range(minPitch, maxPitch);
            balloonPopSound.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource not assigned for BalloonPop sound!");
        }
    }

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originalColour = rend.material.color;
    }
    public void takeDamage()
    {
        //Prevent further damage after being "killed"
        if (isDying) return;

        Health -= 1;
        if (Health <= 0)
        {
            //Mark as dying
            isDying = true;
            //Turn invisible while dying and disable collisions
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            PlayBalloonPopSound();
            Score.Instance.scoreIncreaser();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject, balloonPopSound.clip.length);
        }
        StartCoroutine(FlashEffect());
        PlayTakeDamageSound();
    }

    IEnumerator FlashEffect()
    {
        rend.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        rend.material.color = originalColour;
    }
}
