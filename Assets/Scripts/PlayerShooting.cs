using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public float shootingRange = 10f;
    public Camera myCamera;
    public RaycastHit Hit;


    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Debug.Log("Fired");
            Shooting();
        }
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
