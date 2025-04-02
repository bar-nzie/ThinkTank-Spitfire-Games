using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameplaySubcription PlaneControls;
    [SerializeField] GameObject BulletPrefab;
    
    [SerializeField] float shootDelay = 0.1f;
    
    Rigidbody rb;

    float Timer;
    public ParticleSystem muzzleFlashParticleSystem;
    public ParticleSystem muzzleFlashParticleSystem1;
    private bool isShooting = false;

    bool ActionButton = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Timer = shootDelay;
        muzzleFlashParticleSystem.Stop();
        muzzleFlashParticleSystem1.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaneControls.ActionButton)
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
                GameObject MLI_bullet = Instantiate(BulletPrefab, rb.position, rb.rotation);
            }
        }
        else
        {
            muzzleFlashParticleSystem.Stop();
            muzzleFlashParticleSystem1.Stop();
            Timer = shootDelay;
        }
    }
}
