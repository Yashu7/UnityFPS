using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public float shootingRange = 8f;
    public Camera myCamera;
    public RaycastHit Hit;
    
    public int Ammo = 100;
    public float fireRate = 0.00005F;
    public float nextFire;


    void Update()
    {
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
                recieveDamage.TakeDamage(1);
              


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
