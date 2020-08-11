using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
   public Rigidbody player;
   public Rigidbody ball;
   public Transform playerCamera;
   public float maxSpeed = 10;
   public float baseBallThrust = 20.0f;

   private float _throwKeyPressedStartTime;
   private BallController _ballController;

   void Start()
   {
      player = GetComponent<Rigidbody>();
      _ballController = new BallController(playerCamera, ball, baseBallThrust);
   }

   void Update()
   {
      float inputHorX = Input.GetAxis("Horizontal");
      float inputVertY = Input.GetAxis("Vertical");
      PlayerMovement(inputHorX, inputVertY);

      if (Input.GetMouseButtonDown(0))
      {
         _throwKeyPressedStartTime = Time.time;
      }

      if (Input.GetMouseButtonUp(0))
      {
         _ballController.BallActionHandler(player.transform.position, player.transform.forward, _throwKeyPressedStartTime);
      }
   }

   void PlayerMovement(float x, float y)
   {
      Vector3 playerMovement = new Vector3(x, 0f, y) * maxSpeed * Time.deltaTime;
      transform.Translate(playerMovement, Space.Self);
   }
}
