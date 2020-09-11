using System;
using System.Collections.Generic;
using UnityEngine;

// Source: https://stackoverflow.com/a/56715254/1956540
// Note: Script is attached to the Canvas object in Unity
internal class UnityMainThreadHelper : MonoBehaviour
{
   internal static UnityMainThreadHelper wkr;
   Queue<Action> jobs = new Queue<Action>();

   void Awake()
   {
      wkr = this;
   }

   void Update()
   {
      while (jobs.Count > 0)
         jobs.Dequeue().Invoke();
   }

   internal void AddJob(Action newJob)
   {
      jobs.Enqueue(newJob);
   }
}