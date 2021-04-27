using UnityEngine;

namespace AGP
{
    namespace EetuI
    {
        namespace Player
        {
            [RequireComponent(typeof(CharacterController))]
            public class PlayerMovement : MonoBehaviour
            {
                private CharacterController characterController;
                private float speed;

                [Range(0f, 10f)] [SerializeField] private float walkingSpeed = 3f;
                [Range(0f, 10f)] [SerializeField] private float runningSpeed = 6f;
                [Tooltip("Ground check settings in the GroundCheck child")]
                [SerializeField] private GroundCheck groundCheck;

                private float gravity = -9.81f;
                private Vector2 velocity; //for implementing gravity

                private void Start() => characterController = GetComponent<CharacterController>();

                void Update()
                {
                    speed = Input.GetKey(KeyCode.LeftShift) ? runningSpeed : walkingSpeed;
                    Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

                    movementInput.Normalize(); // Normalizing the input so walking diagonally isn't faster.

                    if (groundCheck.IsGrounded() && velocity.y < 0f) velocity.y = -1f;
                    velocity.y += gravity * Time.deltaTime;

                    Vector3 movement = ((transform.forward * movementInput.y) + (transform.right * movementInput.x)) * speed + (Vector3.up * velocity.y);
                    characterController.Move(movement * Time.deltaTime);
                }
            }
        }
    }
}
