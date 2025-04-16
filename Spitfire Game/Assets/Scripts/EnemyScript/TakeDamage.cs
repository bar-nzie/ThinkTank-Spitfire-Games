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

    [SerializeField] AudioSource takeDamageSound;

    [SerializeField] float minPitch = 0.95f;
    [SerializeField] float maxPitch = 1.05f;

    void PlayTakeDamageSound()
    {
        takeDamageSound.pitch = Random.Range(minPitch, maxPitch);
        takeDamageSound.Play();
    }

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originalColour = rend.material.color;
    }
    public void takeDamage()
    {
        Health -= 1;
        if (Health <= 0)
        {
            Score.Instance.scoreIncreaser();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
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
