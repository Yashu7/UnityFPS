using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{

    //Enemy Shooting
    public float fireRate = 1.0F;
    public float nextFire;


    //Looking.
    public float lookRadius = 10f;
    public Quaternion myRotation;

    //Player's Info
    public Transform Player;

    public float DistanceToPlayer;

    public void Start()
    {
        Player = GameObject.Find("Player").transform;
        
    }
    public void Update()
    {

        DistanceToPlayer = Vector3.Distance(Player.position, transform.position);
        if (DistanceToPlayer < 15)
        {
            StopMovement();
        }
        if(DistanceToPlayer >= 15)
        {
            MoveTowards();
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

        gameObject.GetComponent<NavMeshAgent>().transform.LookAt(Player);
        gameObject.GetComponent<NavMeshAgent>().destination = Player.position;

    }

    public void StopMovement()
    {
        Rotate(Player);
        gameObject.GetComponent<NavMeshAgent>().transform.LookAt(Player);
        gameObject.GetComponent<NavMeshAgent>().destination = transform.position;
    }

}
