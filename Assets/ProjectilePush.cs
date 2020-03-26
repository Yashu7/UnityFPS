using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePush : MonoBehaviour
{
    public GameObject playerPosition;
    public Vector3 direction;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerPosition = GameObject.Find("Player");
        direction = playerPosition.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, direction, 5 * Time.deltaTime);
        

    }
    void FixedUpdate()
    {
        
    }
}
