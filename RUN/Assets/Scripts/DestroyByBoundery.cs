using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundery : MonoBehaviour
{
 
 void OnTriggerEnter(Collider col)
   {
    if (col.tag == "Money")
    {
        Destroy (gameObject);
    }
   }
}