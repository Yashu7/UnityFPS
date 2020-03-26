using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StairsSystem : MonoBehaviour
{
    public GameObject Stairs;
    public static List<GameObject> Stairway;
    public float i = 0;
    public float y = 0;
    public float startingY = 13F;
    public float startingZ = 59F;
    public NavMeshSurface surface;
    


    public void Awake()
    {
        Stairway = new List<GameObject>();
        
        StartCoroutine(GenerateStairs());
        StartCoroutine(RemoveStairs());
        
    }

    public IEnumerator GenerateStairs()
    {
        do
        {
            i = i + startingY;
            y = y + startingZ;
            
            Stairway.Add((Instantiate(Stairs, new Vector3(1, i, y), Quaternion.identity)));
            Stairway[Stairway.Count - 1].transform.SetParent(transform);

            surface.BuildNavMesh();

            yield return new WaitForSeconds(5F);
        } while (true);
    }
    public IEnumerator RemoveStairs()
    {
        do
        {
            yield return new WaitForSeconds(10F);
            if (Stairway.Count > 1)
            {
                Destroy(Stairway[0]);
                Stairway.RemoveAt(0);
                
            }


        } while (true);
    }
}
