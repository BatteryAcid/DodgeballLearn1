using UnityEngine;

public class BallActionHandler
{
   private Transform _playerCamera;
   private Rigidbody _ball;
   private float _baseBallThrust;
   private float _yAxisSpawnPointAdjustment = 2.0f;

   public BallActionHandler(Transform playerCamera, Rigidbody ball, float baseBallThrust)
   {
      _playerCamera = playerCamera;
      _ball = ball;
      _baseBallThrust = baseBallThrust;
   }

   public void ThrowBall(Vector3 playerPosition, Vector3 playerForward, float throwKeyPressedStartTime)
   {
      //Debug.Log((Time.time - throwKeyPressedStartTime).ToString("00:00.00"));
      float throwKeyPressedTime = Time.time - throwKeyPressedStartTime;

      if (_ball != null)
      {
         //Debug.Log("Throwing ball");

         Vector3 spawnPos = GetSpawnPointInFrontOfPlayer(playerPosition, playerForward);

         // For when there is mountainous terrain or obstacles and you don't want the ball to be thrown inside something
         if (!Physics.CheckSphere(spawnPos, 0.5f))
         {
            _ball.position = spawnPos;
            _ball.velocity = new Vector3(0, 0, 0);

            _ball.AddForce(DetermineVectorOfThrow() * DetermineThrustOfBall(throwKeyPressedTime), ForceMode.Impulse);

            GameMessage throwMessage = new GameMessage("OnMessage", WebSocketService.ThrowOp);
            WebSocketService.Instance.SendWebSocketMessage(JsonUtility.ToJson(throwMessage));
         }
      }
   }

   private float DetermineThrustOfBall(float throwKeyPressedTime)
   {
      float thrustOfBall = _baseBallThrust * 1.25f;
      if (throwKeyPressedTime >= 1.5)
      {
         thrustOfBall = _baseBallThrust * 2.5f;
      }
      else if (throwKeyPressedTime >= 1)
      {
         thrustOfBall = _baseBallThrust * 2.0f;
      }
      else if (throwKeyPressedTime >= .5)
      {
         thrustOfBall = _baseBallThrust * 1.75f;
      }

      // Debug.Log("Throw speed: " + thrustOfBall);

      return thrustOfBall;
   }

   // Returns a point just in front of the facing direction/vector of the player
   private Vector3 GetSpawnPointInFrontOfPlayer(Vector3 playerPosition, Vector3 playerForward)
   {
      Vector3 spawnPos = playerPosition + playerForward * 1.3f;

      // moves the spawn position up the Y axis 
      spawnPos.y = spawnPos.y + _yAxisSpawnPointAdjustment;
      return spawnPos;
   }

   private Vector3 DetermineVectorOfThrow()
   {
      Vector3 cameraVector = _playerCamera.transform.forward;
      cameraVector.y += 0.2f; // shim to get the throw vector more playable
      return cameraVector;
   }

   // DEBUG: Use to debug what the object is overlapping with
   private void PrintOverlapShereObjects(Vector3 spawnPos)
   {
      Collider[] hitColliders = Physics.OverlapSphere(spawnPos, 0.5f);
      int i = 0;
      while (i < hitColliders.Length)
      {
         Debug.Log(hitColliders[i].name);
         i++;
      }
   }
}
