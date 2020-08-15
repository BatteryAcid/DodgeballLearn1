using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementController : MonoBehaviour
{
   public Rigidbody player;
   public Rigidbody ball;
   public Transform playerCamera;
   public float maxSpeed = 10;
   public float baseBallThrust = 20.0f;

   private float _throwKeyPressedStartTime;
   private BallActionHandler _ballActionHandler;

   void Start()
   {
      // For now just hit this variable to create the singleton
      WebSocketService.Instance.init();

      player = GetComponent<Rigidbody>();
      _ballActionHandler = new BallActionHandler(playerCamera, ball, baseBallThrust);
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

         // allows us to click the button with over it with the mouse
         if (EventSystem.current.IsPointerOverGameObject())
            return; 
            
         _ballActionHandler.ThrowBall(player.transform.position, player.transform.forward, _throwKeyPressedStartTime);
      }
   }

   void PlayerMovement(float x, float y)
   {
      Vector3 playerMovement = new Vector3(x, 0f, y) * maxSpeed * Time.deltaTime;
      transform.Translate(playerMovement, Space.Self);
   }
}
