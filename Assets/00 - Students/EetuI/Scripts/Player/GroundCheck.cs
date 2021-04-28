using UnityEngine;

namespace ObjectInteractionGame
{
    namespace EetuI
    {
        namespace Player
        {
            public class GroundCheck : MonoBehaviour
            {
                [SerializeField] private float checkRadius = 0.1f;
                [SerializeField] private LayerMask whatIsGround;
                [SerializeField] private bool drawCheckRadius;

                public bool IsGrounded() => Physics.CheckSphere(transform.position, checkRadius, whatIsGround);

                private void OnDrawGizmos()
                {
                    if (drawCheckRadius)
                    {
                        Gizmos.color = Color.green;
                        Gizmos.DrawSphere(transform.position, checkRadius);
                    }
                }
            }
        }
    }
}
