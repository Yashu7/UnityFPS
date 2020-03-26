using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooterAI : MonoBehaviour
{
    
    public enum State { Patroling, Attacking, Hiding, Engage };
    public CharacterController controller;
    public State enemyState = State.Patroling;
    public Transform Player;
    public List<Transform> healingPoints = new List<Transform>();
    public Quaternion myRotation;
    public float shootingDistance = 10f;
    public int ammo = 5;
    public float fireRate = 1.0F;
    public float nextFire;
    public Rigidbody rb3d;
    public float HealthLimit;
    public float distance;
    public GameObject projectile;
    public List<Vector3> patrollingPosition = new List<Vector3>();
    public float AttackingDistance;
    public RaycastHit target;
    public static int enemyCount;
    public float lookRadius = 10f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void Start()
    {
        State enemyState = State.Patroling;
        rb3d = GetComponent<Rigidbody>();
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
       
        if (Physics.Raycast(transform.position, transform.forward, out target, shootingDistance))
        {
            if (target.transform.tag == "Players")
            {
                if (target.transform.position != transform.position)
                {
                    Player = target.transform;
                }
                else { Player = null; }

            }
            
        }

        //if (Player != null)
        //{
        if (Player == null)
        {
            distance = 30;
        } else
        {
            distance = Vector3.Distance(Player.position, transform.position);
                 }
        
            if (distance <= 20 && distance > 10)
            {
                enemyState = State.Engage;
            }
            if (distance >= 21)
            {

                if (gameObject.GetComponent<Fire>().HealthLevel() >= HealthLimit)
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
            if (distance <= AttackingDistance && gameObject.GetComponent<Fire>().HealthLevel() > HealthLimit)
            {
                enemyState = State.Attacking;
            }
            if (gameObject.GetComponent<Fire>().HealthLevel() < HealthLimit)
            {
                if (isHealthPosition())
                {
                    enemyState = State.Hiding;
                }
            }
            switch (enemyState)
            {
                case State.Engage:
                    if (enemyState == State.Engage)
                    {
                        MoveTowards();
                    }
                    break;
                case State.Attacking:






                    if (distance <= AttackingDistance)
                    {

                        Rotate(Player);
                        if (Time.time > nextFire)
                        {

                            Shooting();
                            Evade();
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



        //}
    }
    public bool isHealthPosition()
    {
        foreach (Transform f in healingPoints)
        {
            if (f.gameObject.activeSelf == true) return true;
        }
        return false;
    }
    public void FindHealth()
    {
        var nearestPoint = float.MaxValue;
        Transform hpLocation = null;
        //Transform hpPos = healingPoints[Random.Range(0, healingPoints.Count)];
        foreach (Transform t in healingPoints)
        {
            if (t.gameObject.activeSelf == true)
            {
                if (Vector3.Distance(t.position, transform.position) < nearestPoint)
                {
                    nearestPoint = Vector3.Distance(t.position, transform.position);
                    hpLocation = t;
                }
            }
            

        }
        if (hpLocation != null)
        {
            gameObject.GetComponent<NavMeshAgent>().destination = hpLocation.position;
        }
    }
    public void NextPosition()
    {

        gameObject.GetComponent<NavMeshAgent>().destination = patrollingPosition[Random.Range(0, patrollingPosition.Count)];
    }
    public void MoveTowards()
    {
        Rotate(Player);
        
        gameObject.GetComponent<NavMeshAgent>().transform.LookAt(Player);
        gameObject.GetComponent<NavMeshAgent>().destination = Player.position;

    }
    public void Evade()
    {
        Rotate(Player);
        gameObject.GetComponent<NavMeshAgent>().transform.LookAt(Player);
        gameObject.GetComponent<NavMeshAgent>().destination = new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y, transform.position.z + Random.Range(-5, 5));
    }
    public void Shooting()
    {                                                  
        nextFire = Time.time + fireRate;
        gameObject.GetComponent<NavMeshAgent>().destination = transform.position;
        
        RaycastHit Hit;
        if (Physics.Raycast(transform.position, transform.forward, out Hit, shootingDistance))
        {
            Debug.Log(Hit.transform.name);
           
            Fire recieveDamage = Hit.transform.GetComponent<Fire>();
            if (recieveDamage != null)
            {
                recieveDamage.TakeDamage(10);
                
            }

        }
    }


    public void  Rotate(Transform followPosition)
    {
        myRotation = Quaternion.LookRotation(followPosition.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, myRotation, 10 * Time.deltaTime);
    }
    public void RotateAround()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
    }
   
}
