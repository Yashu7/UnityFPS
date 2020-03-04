using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterAI : MonoBehaviour
{
    public enum State { Patroling, Attacking, Hiding};
    public CharacterController controller;
    public State enemyState = State.Patroling;
    public Transform Player;

    public float distance;

    void Start()
    {
       
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        distance = Vector3.Distance(Player.position, transform.position);
        if(distance <= 30 && distance > 15)
        {
            Patrolling();

        }
        if(distance <= 15)
        {
            Shooting();
        }
    }
    public void Patrolling()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, 5f * Time.deltaTime);
    }
    public void Shooting()
    {
        Debug.Log("SHooting");
    }
}
