using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;

    Enemy enemy;

    public float Bullet_Speed = 10.0f;

    // Start is called before the first frame update
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = (Vector3.forward * Bullet_Speed);
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (Vector3.forward * Bullet_Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Wall")
        {
            Destroy(this.gameObject);
        }
        else if (other.name != "PlaneTest" && other.name != "Bullet(Clone)")
        {
            other.gameObject.GetComponent<TakeDamage>().takeDamage();
            Destroy(this.gameObject);
        }
    }
}
