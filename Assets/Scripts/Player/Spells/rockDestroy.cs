using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockDestroy : MonoBehaviour
{
   private float timeToDestroy = 2f;

   private void Update()
   {
      if (timeToDestroy <= 0)
      {
         Destroy(gameObject);
      }
      else
      {
         timeToDestroy -= Time.deltaTime;
      }
   }
}
