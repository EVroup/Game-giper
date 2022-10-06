using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject chtoSpawnit;

    void Start() 
    {
       
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-5, 6), 20, Random.Range(-5, 6));
            Instantiate(chtoSpawnit, randomSpawnPosition, Quaternion.identity);
        }

       
    
    }
}        