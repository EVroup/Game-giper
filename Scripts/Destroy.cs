using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//входит в триггер
public class DestroyByBoundery : MonoBehaviour
{
   private void OnTriggerExit(Collider other) {
    Destroy(other.gameObject);
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrig : MonoBehaviour
{
 
   //покидает триггер
   private void OnTriggerEnter(Collider other) 
   {
    if (other.gameObject.CompareTag("Bomb"))
        {
            Destroy(other.gameObject, 5);//удаление через некоторое времф
        }
   }
}