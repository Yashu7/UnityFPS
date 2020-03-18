using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void RestoreHealth(float restore)
    {
        if (health < maxHealth)
        {
            health += restore;
        }
    }
    public float HealthLevel()
    {
        return health;
    }

    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
