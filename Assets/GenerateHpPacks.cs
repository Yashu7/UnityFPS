using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHpPacks : MonoBehaviour
{
    
    public GameObject[] healthPoints;
    

    public void Start()
    {
        StartCoroutine(refillHealthPoints());
    }


    public void Update()
    {
       
    }

    public void areHealthPointsNull()
    {
        foreach(GameObject gb in healthPoints)
        {
            Debug.Log("HP refilling");
            if (gb.activeSelf == false)
            {
                gb.SetActive(true);
            }
        }
        
    }

    public IEnumerator refillHealthPoints()
    {
        while (true)
        {
            areHealthPointsNull();
            yield return new WaitForSeconds(20);
        }
       
    }
}
