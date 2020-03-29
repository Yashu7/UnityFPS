using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{

    //Enemy Shooting
    public float fireRate = 1.0F;
    public float nextFire;
    public GameObject Projectile;
    public float projectileSpeed = 100;
    public float speed = 7F;

    //Looking.
    public float lookRadius = 10f;
    public Quaternion myRotation;

    //Player's Info
    public Transform Player;

    public float DistanceToPlayer;
    public float Distance;


    public void Start()
    {
        Player = GameObject.Find("Player").transform;
    

    }
  
    public void Update()
    {
        
        if (Player == null) { return; }
        DistanceToPlayer = Vector3.Distance(Player.position, transform.position);
        if (DistanceToPlayer < Distance)
        {
            StopMovement();
            if (Time.time > nextFire)
            {
                FireProjectile();
            }
        }
        if(DistanceToPlayer >= Distance)
        {
            MoveTowards();
        }
        //if(gameObject.GetComponent<NavMeshAgent>().isOnNavMesh == false)
        //{
          
        //    Destroy(this.gameObject);
        //}
        if(DistanceToPlayer > 100)
        {
            Destroy(this.gameObject);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    //Face another gameobject
    public void Rotate(Transform followPosition)
    {
        myRotation = Quaternion.LookRotation(followPosition.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, myRotation, 10 * Time.deltaTime);
    }
    public void MoveTowards()
    {
        Rotate(Player);
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position,new Vector3((Player.position.x +Random.Range(-10,10)),Player.position.y,Player.position.z),  step);
        //if(gameObject.GetComponent<NavMeshAgent>().isOnNavMesh == false) { return; }
        //gameObject.GetComponent<NavMeshAgent>().transform.LookAt(Player);
        //gameObject.GetComponent<NavMeshAgent>().destination = Player.position;

    }

    public void StopMovement()
    {
        Rotate(Player);
       
        //if (gameObject.GetComponent<NavMeshAgent>().isOnNavMesh == false) { return; }
        //gameObject.GetComponent<NavMeshAgent>().transform.LookAt(Player);
        //gameObject.GetComponent<NavMeshAgent>().destination = transform.position;
    }

    public void FireProjectile()
    {
        nextFire = Time.time + fireRate;
        Rotate(Player);
        //gameObject.GetComponent<NavMeshAgent>().transform.LookAt(Player);
        
        GameObject bullet = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
    }

}
