using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemiesGenerator : MonoBehaviour
{
    public GameObject Enemy;

    public void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    public IEnumerator GenerateEnemies()
    {
        
        do
        {
            Vector3 v3 = new Vector3(StairsSystem.Stairway[StairsSystem.Stairway.Count - 1].transform.position.x, StairsSystem.Stairway[StairsSystem.Stairway.Count - 1].transform.position.y, StairsSystem.Stairway[StairsSystem.Stairway.Count - 1].transform.position.z);
            yield return new WaitForSeconds(5F);
            Instantiate(Enemy,v3, Quaternion.identity).transform.SetParent(transform);
        } while (true);
    }
}
