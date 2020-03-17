using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoxBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider col)
    {
        if(col.transform.name == "Player")
        {
            col.transform.GetComponent<Fire>().RestoreHealth(10);
            Destroy(this.gameObject);
        }
        //if(col.transform.name == "Enemy")
        //{
            col.transform.GetComponent<Fire>().RestoreHealth(10);
            Destroy(this.gameObject);
        //}
    }
}
