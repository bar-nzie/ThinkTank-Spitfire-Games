using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameplaySubcription PlaneControls;
    Rigidbody rb;
    public GameObject BulletPrefab;
    public float Firerate = 1.0f;

    float Timer;

    bool ActionButton = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Timer = Firerate;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaneControls.ActionButton)
        {
            if (Timer < Firerate)
            {
                Timer += Time.deltaTime;
            }
            else
            {

                Debug.Log("Button Pressed");
                if (BulletPrefab == null)
                {
                    Debug.LogWarning("Bullet prefab is not assigned.");
                    return;
                }
                Timer = 0;
                GameObject MLI_bullet = Instantiate(BulletPrefab, rb.position, rb.rotation);
            }
        }
        else
        {
            Timer = Firerate;
        }
    }
}
