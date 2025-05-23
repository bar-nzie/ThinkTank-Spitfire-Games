using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionShooting : MonoBehaviour
{
    private NarrationScript narrationScript;

    [SerializeField] MenuSubcription MenuControls;
    
    //Audio
    [SerializeField] float minPitch = 0.95f;
    [SerializeField] float maxPitch = 1.05f;
    [SerializeField] AudioSource gunfire;

    Rigidbody rb;
    [SerializeField] float shootDelay = 0.1f;
    float Timer;

    bool autoShootOn = false;
    int random1;
    int random2;

    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] Transform bulletSpawnPoint1;
    [SerializeField] ParticleSystem muzzleFlashParticleSystem;
    [SerializeField] ParticleSystem muzzleFlashParticleSystem1;
    
    //private bool isShooting = false;

    //bool ActionButton = false;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(ShootingOn());

        //rb = GetComponent<Rigidbody>();
        narrationScript = FindObjectOfType<NarrationScript>();

        Timer = shootDelay;
        muzzleFlashParticleSystem.Stop();
        muzzleFlashParticleSystem1.Stop();

        //planePosition = Vector3(rb.position.x + 3, rb.position.y, rb.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (autoShootOn)
        {
            if (Timer < shootDelay)
            {
                Timer += Time.deltaTime;
            }
            else
            {

                //Debug.Log("Button Pressed");
                if (BulletPrefab == null)
                {
                    Debug.LogWarning("Bullet prefab is not assigned.");
                    return;
                }
                Timer = 0;
                muzzleFlashParticleSystem.Play();
                muzzleFlashParticleSystem1.Play();
                PlayGunfireSound();
                GameObject MLI_bullet = Instantiate(BulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                GameObject MLI_bullet1 = Instantiate(BulletPrefab, bulletSpawnPoint1.position, bulletSpawnPoint1.rotation);
                
            }
        }
        else
        {
            muzzleFlashParticleSystem.Stop();
            muzzleFlashParticleSystem1.Stop();
            Timer = shootDelay;
        }
    }

    void PlayGunfireSound()
    {
        if (gunfire != null)
        {
            gunfire.pitch = Random.Range(minPitch, maxPitch);
            gunfire.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource not assigned for gunfire sound!");
        }
    }

    private IEnumerator ShootingOn()
    {

        autoShootOn = true;

        random1 = Random.Range(1, 4);

        yield return new WaitForSeconds(random1);

        StartCoroutine(ShootingOff());

    }

    private IEnumerator ShootingOff()
    {

        autoShootOn = false;

        random2 = Random.Range(1, 4);

        yield return new WaitForSeconds(random2);

        StartCoroutine(ShootingOn());

    }
}
