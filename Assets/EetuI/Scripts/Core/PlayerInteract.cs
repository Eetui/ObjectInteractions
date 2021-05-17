using AGP.EetuI.Player;
using UnityEngine;
using AGP.EetuI.Events;

namespace AGP
{
    namespace EetuI
    {
        namespace Core
        {
            public class PlayerInteract : MonoBehaviour
            {
                [Header("General")]
                [SerializeField] private Transform camTransform;
                [SerializeField] private GroundCheck groundCheck;

                public IInteractable interactable = null;
                public IThrowable throwable = null;

                [Header("Interaction and Throw settings")]
                [SerializeField] private float interactRange = 2f;
                [SerializeField] private KeyCode interactionKey = KeyCode.F;
                [SerializeField] private KeyCode throwKey = KeyCode.E;
                [SerializeField] private LayerMask interactableLayerMask;

                public KeyCode InteractionKey
                {
                    get { return interactionKey; }
                }

                public KeyCode ThrowKey
                {
                    get { return throwKey; }
                }

                private IInteractable lastFrameInteractable = null;
                private IThrowable lastFrameThrowable = null;


                [Header("Interaction Events")]
                [SerializeField] private GameEvent onInteractionChanged;
                [SerializeField] private GameEvent onThrowableChanged;

                private void Update()
                {
                    interactable = null;
                    throwable = null;

                    Physics.Raycast(camTransform.position, camTransform.TransformDirection(Vector3.forward), out var hit, interactRange, interactableLayerMask);
                    var hitTransform = hit.transform;

                    if (hitTransform != null)
                    {
                        if (hitTransform.TryGetComponent(out interactable) && groundCheck.IsGrounded())
                        {
                            if (Input.GetKeyDown(interactionKey))
                            {
                                interactable.Interact();
                                onInteractionChanged?.Invoke();
                            }
                        }

                        if (hitTransform.TryGetComponent(out throwable))
                        {
                            if (Input.GetKeyDown(throwKey))
                            {
                                throwable.Throw();
                                onThrowableChanged?.Invoke();
                            }
                        }
                    }

                    CheckForInteractionChanges();
                }

                private void CheckForInteractionChanges()
                {
                    if (lastFrameInteractable != interactable)
                    {
                        onInteractionChanged?.Invoke();
                    }

                    if (lastFrameThrowable != throwable)
                    {
                        onThrowableChanged?.Invoke();
                    }

                    lastFrameInteractable = interactable;
                    lastFrameThrowable = throwable;
                }
                void OnDrawGizmos()
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(camTransform.position, camTransform.position + camTransform.TransformDirection(Vector3.forward) * interactRange);
                }
            }
        }
    }
}