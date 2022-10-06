using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
public GameObject spawm;

void Start()
{
DoIt();
}

void DoIt()
{
          Vector3 randomSpawnPosition = new Vector3(Random.Range(-50,50), 5, Random.Range(-50, 50));
            Instantiate(spawm, randomSpawnPosition, Quaternion.identity);
          { Invoke("DoIt", 1f);}
}
}
      
  