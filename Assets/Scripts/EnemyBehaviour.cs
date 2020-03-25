using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    //Looking.
    public float lookRadius = 10f;
    public Quaternion myRotation;

    //Player's Info
    public Transform Player;

    public void Start()
    {
        Player = GameObject.Find("Player").transform;
        
    }
    public void Update()
    {
        MoveTowards();
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
}
