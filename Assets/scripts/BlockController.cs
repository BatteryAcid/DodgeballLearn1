using UnityEngine;

public class BlockController : MonoBehaviour
{
   private StatusController _statusController;

   void Start() {
      _statusController = GameObject.FindObjectOfType<StatusController>();
   }

   // Detect collisions between the GameObjects with Colliders attached
   void OnCollisionEnter(Collision collision)
   {
      // Check for collision with ball
      if (collision.gameObject.name == "ball")
      {
         Debug.Log("Block Hit! ******");
         _statusController.SetText("GAME OVER");
      }
   }
}
