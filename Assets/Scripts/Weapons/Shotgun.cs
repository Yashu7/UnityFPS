using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shotgun : Weapon
{
    public Shotgun() : base("Shotgun", 15, 20, 30, 1F)
    {
        name = "Shotgun";
        distance = 15;
        damage = 20;
        maxAmmo = 30;
        fireRate = 1F;
    }
}
