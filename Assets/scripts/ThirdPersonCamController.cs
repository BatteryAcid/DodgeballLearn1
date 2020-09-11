using UnityEngine;

public class ThirdPersonCamController : MonoBehaviour
{
   public Transform Target;
   public Transform Player;
   public float RotationSpeed = 1;
   public float zoomSpeed = 2;
   public float zoomMin = -2f;
   public float zoomMax = -10f;

   private Transform _camTransform;
   private float _mouseX, _mouseY, _zoom;
   private bool _cursorLocked = true;

   void Start()
   {
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;

      _camTransform = transform;
      _zoom = -10;

      // set start position
      Player.position = new Vector3(Random.Range(-15.0f, 15.0f), 1, Random.Range(-15.0f, 15.0f));
   }

   void LateUpdate()
   {
      CamControl();
   }

   void Update() {
      if (Input.GetKeyDown("escape") && !_cursorLocked) {
         Cursor.visible = false;
         Cursor.lockState = CursorLockMode.Locked;
         _cursorLocked = !_cursorLocked;
      } else if (Input.GetKeyDown("escape") && _cursorLocked) {
         Cursor.visible = true;
         Cursor.lockState = CursorLockMode.None;
         _cursorLocked = !_cursorLocked;
      }
   }

   private void CamControl()
   {
      _zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

      if (_zoom > zoomMin)
         _zoom = zoomMin;

      if (_zoom < zoomMax)
         _zoom = zoomMax;

      _mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
      _mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
      _mouseY = Mathf.Clamp(_mouseY, -2, 60);

      Vector3 dir = new Vector3(0, 0, _zoom);

      Quaternion rotation = Quaternion.Euler(_mouseY, _mouseX, 0);
      if (Input.GetMouseButton(1))
      {
         _camTransform.position = Target.position + rotation * dir;
         _camTransform.LookAt(Target.position);
      }
      else
      {
         _camTransform.position = Target.position + rotation * dir;
         _camTransform.LookAt(Target.position);

         Player.rotation = Quaternion.Euler(0, _mouseX, 0);
      }
   }
}
