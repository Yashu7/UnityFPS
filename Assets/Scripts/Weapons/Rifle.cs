
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[System.Serializable]
public class Rifle : Weapon
{
   public Rifle() : base("Rifle",30,1,500, 0.00005F)
    {
        name = "Rifle";
        distance = 30;
        damage = 1;
        maxAmmo = 500;
        fireRate = 0.00005F;
    }
}
