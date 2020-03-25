using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsSystem : MonoBehaviour
{
    public GameObject Stairs;
    public List<GameObject> Stairway;
    public float i = 0;
    public float y = 0;
    public float startingY = 14.8F;
    public float startingZ = 59.9F;
    public int counter = 0;

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
            
            Stairway.Add(Instantiate(Stairs, new Vector3(1, i, y), Quaternion.identity));
            yield return new WaitForSeconds(3F);
        } while (true);
    }
    public IEnumerator RemoveStairs()
    {
        do
        {
            yield return new WaitForSeconds(13F);
            if (Stairway.Count > 1)
            {
                Destroy(Stairway[counter]);
                counter++;
            }


        } while (true);
    }
}
