using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooterAI : MonoBehaviour
{
    public enum State { Patroling, Attacking, Hiding };
    public CharacterController controller;
    public State enemyState = State.Patroling;
    public Transform Player;
    public List<Transform> healingPoints = new List<Transform>();
    public Quaternion myRotation;
    public float shootingDistance = 80f;
    public int ammo = 5;
    public float fireRate = 1.0F;
    public float nextFire;

    public float distance;
    public GameObject projectile;
    public List<Vector3> patrollingPosition = new List<Vector3>();

    public static int enemyCount;

    void Start()
    {
        State enemyState = State.Patroling;

        enemyCount++;
        controller = gameObject.GetComponent<CharacterController>();
        patrollingPosition.Add(new Vector3(38.76F, -3.3F, -60F));
        patrollingPosition.Add(new Vector3(14, -3.3F, -62));
        patrollingPosition.Add(new Vector3(7, 3.3F, -7));
        patrollingPosition.Add(new Vector3(35, -3.3F, -7));
        patrollingPosition.Add(new Vector3(24, 3.6F, -29));
    }

    void Update()
    {
        Debug.Log(enemyCount);
        if (Player != null)
        {
            distance = Vector3.Distance(Player.position, transform.position);
            if (distance <= 20 && distance > 10)
            {
                enemyState = State.Attacking;
            }
                if (distance >= 21)
            {
                
                if (gameObject.GetComponent<Fire>().HealthLevel() >= 30)
                {
                    enemyState = State.Patroling;
                }
                else
                {
                    if (isHealthPosition())
                    {
                        enemyState = State.Hiding;
                    }
                }
            }
        }
        if (gameObject.GetComponent<Fire>().HealthLevel() < 30)
        {
            if (isHealthPosition())
            {
                enemyState = State.Hiding;
            }
        }
        switch (enemyState)
        {
            case State.Attacking:
                
                   
                        
                        if (enemyState == State.Attacking)
                        {
                            MoveTowards();
                        }

                    
                    if (distance <= 8)
                    {
                        
                        Rotate(Player);
                        if (Time.time > nextFire)
                        {
                            Shooting();
                        }
                    }
                    
                
                break;
            case State.Hiding:
                if (!gameObject.GetComponent<NavMeshAgent>().pathPending && gameObject.GetComponent<NavMeshAgent>().remainingDistance < 0.5F)
                {
                    FindHealth();
                }
                break;
            case State.Patroling:
                if (!gameObject.GetComponent<NavMeshAgent>().pathPending && gameObject.GetComponent<NavMeshAgent>().remainingDistance < 0.5F)
                {
                    NextPosition();
                }
                break;



        }
       
        

    }
    public bool isHealthPosition()
    {
        foreach (Transform f in healingPoints)
        {
            if (f != null) return true;
        }
        return false;
    }
    public void FindHealth()
    {
        Transform hpPos = healingPoints[Random.Range(0, healingPoints.Count)];
        if (hpPos != null)
        {
            gameObject.GetComponent<NavMeshAgent>().destination = hpPos.position;
        }
    }
    public void NextPosition()
    {

        gameObject.GetComponent<NavMeshAgent>().destination = patrollingPosition[Random.Range(0, 4)];
    }
    public void MoveTowards()
    {
        Rotate(Player);
        
        gameObject.GetComponent<NavMeshAgent>().transform.LookAt(Player);
        gameObject.GetComponent<NavMeshAgent>().destination = Player.position;

    }
    public void Shooting()
    {                                                  
        nextFire = Time.time + fireRate;
        gameObject.GetComponent<NavMeshAgent>().destination = transform.position;
        
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.forward, out Hit, shootingDistance))
        {
            Debug.Log(Hit.transform.name);
            ///Instantiate(projectile, transform.position, transform.rotation);
            Fire recieveDamage = Hit.transform.GetComponent<Fire>();
            if (recieveDamage != null)
            {
                recieveDamage.TakeDamage(10);
                //if (ammo > 0)
                //{
                //    recieveDamage.TakeDamage(10);
                //    ammo -= 1;
                //}
                //else
                //{
                //    Debug.Log("Not enough ammo");
                //}
            }

        }
    }


    public void  Rotate(Transform followPosition)
    {
        myRotation = Quaternion.LookRotation(followPosition.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, myRotation, 10 * Time.deltaTime);
    }
}
