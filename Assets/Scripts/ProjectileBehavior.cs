using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public void OnTriggerEnter(Collider player)
    {
     if(player.transform.name == "Player")
        {
            player.GetComponent<Fire>().TakeDamage(10);
            DestoryProjectile();
        }
    }
    public void Start()
    {
        Invoke("DestoryProjectile", 3F);
    }
    public void DestoryProjectile()
    {
        Destroy(this.gameObject);
    }
}
