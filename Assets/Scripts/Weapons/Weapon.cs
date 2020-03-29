using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Weapon
{
    public string name;
    public float distance;
    public float damage;
    public int maxAmmo;
    public float fireRate;


    public Weapon(string name, float distance, float damage, int maxAmmo, float fireRate)
    {
        this.name = name;
        this.distance = distance;
        this.damage = damage;
        this.maxAmmo = maxAmmo;
        this.fireRate = fireRate;
    }

    
    
}
