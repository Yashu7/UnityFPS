using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooterAI : MonoBehaviour
{
    public enum State { Patroling, Attacking, Hiding};
    public CharacterController controller;
    public State enemyState = State.Patroling;
    public Transform Player;
    public Quaternion myRotation;

    

    public float distance;

    void Start()
    {
       
        controller = gameObject.GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {

        distance = Vector3.Distance(Player.position, transform.position);
        if(distance <= 30 && distance > 5)
        {
            MoveTowards();

        }
        if(distance <= 5)
        {
            Shooting();
        }


    }
    public void MoveTowards()
    {
        Rotate(Player);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x, transform.position.y, Player.position.z), 5f * Time.deltaTime);
        //gameObject.GetComponent<Rigidbody>().MovePosition(Player.position + transform.right * Time.fixedDeltaTime);
        gameObject.GetComponent<NavMeshAgent>().transform.LookAt(Player);
        gameObject.GetComponent<NavMeshAgent>().destination = Player.position;

    }
    public void Shooting()
    {
        Rotate(Player);
        Debug.Log("SHooting");
    }

    public void  Rotate(Transform followPosition)
    {
        myRotation = Quaternion.LookRotation(followPosition.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, myRotation, 10 * Time.deltaTime);
    }
}
