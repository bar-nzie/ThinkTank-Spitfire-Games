using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public int Health;
    public void takeDamage()
    {
        Health -= 1;
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
