using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemiesGenerator : MonoBehaviour
{
    public GameObject[] Enemy;
    public GameObject Player;

    public void Start()
    {
        Invoke("Generating", 8.0f);
      
    }
    public void Generating()
    {
        StartCoroutine(GenerateEnemies());
    }
    public IEnumerator GenerateEnemies()
    {
        
        do
        {
            foreach (GameObject e in Enemy)
            {
                Vector3 v3 = new Vector3(Player.transform.position.x + Random.Range(-8,8), Player.transform.position.y + 5, Player.transform.position.z + Random.Range(40,60));
                
                Instantiate(e, v3, Quaternion.identity).transform.SetParent(transform);
            }
            yield return new WaitForSeconds(5F);
        } while (true);
    }
}
