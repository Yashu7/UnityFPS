using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerShooting : MonoBehaviour
{

    public float shootingRange = 8f;
    public Camera myCamera;
    public RaycastHit Hit;
    public float damage = 0f;
    
    public int Ammo = 100;
    public float fireRate = 0.00005F;
    public float nextFire;
    public List<Weapon> myWeapon = new List<Weapon>();
    Shotgun myShotgun = new Shotgun();
    Rifle myRifle = new Rifle();

    public int i = 0;
    public void Start()
    {
        myWeapon.Add(myShotgun);
        myWeapon.Add(myRifle);
        ChangeWeapon(myWeapon[i]);
    }

    public void ChangeWeapon(Weapon wep)
    {
        fireRate = wep.fireRate;
        shootingRange = wep.distance;
        damage = wep.damage;
    }
    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            if(i == 0) { i = 1; }
            else { i = 0; }
            ChangeWeapon(myWeapon[i]);
        }

        if(Input.GetButton("Fire1"))
        {
            Debug.Log("Fired");
            if (Ammo > 0)
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Ammo--;
                    Shooting();
                }
            }
        }
    }
    public string ammoAmount()
    {
        return Ammo.ToString();
    }
    void Shooting()
    {
        
        
        if(Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out Hit, shootingRange))
        {

            Fire recieveDamage = Hit.transform.GetComponent<Fire>();
            Debug.Log(Hit.transform.name);
            if(recieveDamage != null)
            {
                recieveDamage.TakeDamage(damage);
              


            }
            
        }
        
    }
    public bool isTargeted(GameObject enemy)
    {
        if (Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out Hit, shootingRange))
        {
            if (enemy.transform.name == Hit.transform.name)
            {
                return true;
            }
            else { return false; }

        }
        else { return false; }
    }
}
