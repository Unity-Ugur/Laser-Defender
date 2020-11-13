using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.name == "Laser(Clone)")
      {
         Destroy(other.gameObject);
      }
      return;
   }
}
