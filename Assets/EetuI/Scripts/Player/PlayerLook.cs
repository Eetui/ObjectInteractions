using UnityEngine;

namespace AGP
{
    namespace EetuI
    {
        namespace Player
        {
            /*
             * Camera pitch refers to up and down motion
             *
             * Yaw refres to left and right motion.
             * In this case we are rotating the players yaw so we are always facing where we are moving.
             */
            public class PlayerLook : MonoBehaviour
            {
                [SerializeField] private Transform playerCamera;

                [Range(0f, 10f)]
                [SerializeField] private float sensitivity = 1.9f;
                [SerializeField] private bool invertedLook = false;
                [SerializeField] private bool hideMouseOnStart = true;
                private float cameraPitch = 0f;

                private void Start()
                {
                    if (hideMouseOnStart)
                    {
                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                    }
                }

                private void Update()
                {
                    Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

                    CalculateCameraPitch(mouseInput.y);

                    //yaw
                    transform.Rotate(Vector3.up * mouseInput.x * sensitivity);
                }

                private void CalculateCameraPitch(float mouseInputY)
                {
                    if (invertedLook) cameraPitch += mouseInputY * sensitivity;
                    else cameraPitch -= mouseInputY * sensitivity;

                    cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f);

                    playerCamera.localEulerAngles = Vector3.right * cameraPitch;
                }
            }
        }
    }
}
