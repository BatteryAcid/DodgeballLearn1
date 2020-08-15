using UnityEngine;

public class BlockController : MonoBehaviour
{
   // Detect collisions between the GameObjects with Colliders attached
   void OnCollisionEnter(Collision collision)
   {
      // Check for collision with ball
      if (StatusController.Instance.IsGamePlayActive() && collision.gameObject.name == "ball")
      {
         Debug.Log("Block Hit!");
         
         // notify server that we have a block hit
         WebSocketService.Instance.BlockHit();
      }
   }
}
