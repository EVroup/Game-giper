using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrig : MonoBehaviour
{
 
 
   private void OnTriggerEnter(Collider other) 
   {
    if (other.gameObject.CompareTag("Bomb"))
        {
            Destroy(other.gameObject, 5);
        }
   }
}