using AGP.EetuI.Core;
using UnityEngine;

namespace AGP
{
    namespace EetuI
    {
        [RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(ChangeMaterial))]
        public class PickableObject : MonoBehaviour, IInteractable, IThrowable
        {
            public string objectName { get; set; }
            [SerializeField] private string _objectName;
            [SerializeField] private float throwForce;

            private Rigidbody rb;
            private GameObject pickUpPoint;
            private Vector3 target;

            private float speed = 0f;
            private float minSpeed = 150f;
            private float maxSpeed = 275f;

            private readonly float maxDistance = 2.5f;
            private float minDistance = 0.1f;
            private float distance;
            public bool IsPickedUp { get; private set; }

            private bool lastFramePickedUp;

            [SerializeField] private ChangeMaterial changeMaterial;

            private void Start()
            {
                objectName = _objectName;
                pickUpPoint = GameObject.Find("PickUpPoint").gameObject;
                rb = GetComponent<Rigidbody>();
                rb.interpolation = RigidbodyInterpolation.Interpolate;
            }

            private void Update()
            {
                if (lastFramePickedUp != IsPickedUp) changeMaterial.ChangeMaterials();

                lastFramePickedUp = IsPickedUp;

                if (!IsPickedUp) return;

                target = pickUpPoint.transform.position;
                distance = Vector3.Distance(target, transform.position);

                if (distance > maxDistance && IsPickedUp) Drop();
            }

            private void FixedUpdate()
            {
                if (IsPickedUp) MoveObject();
            }

            public string GetInteractionText() => IsPickedUp ? $"Drop {objectName}" : $"Pick Up {objectName}";

            public void Interact()
            {
                if (IsPickedUp) Drop();
                else PickUp();
            }

            public string GetTwhorableText() => $"Throw {objectName}";

            public void Throw()
            {
                Drop();
                rb.AddForce(pickUpPoint.transform.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);
            }

            private void MoveObject()
            {
                if (distance > minDistance)
                {
                    speed = Mathf.SmoothStep(minSpeed, maxSpeed, distance / maxDistance);
                    speed *= Time.fixedDeltaTime;
                    Vector3 direction = target - rb.position;
                    rb.velocity = direction.normalized * speed;
                }
                else rb.velocity = Vector3.zero;
            }

            private void PickUp()
            {
                distance = 0;
                IsPickedUp = true;
                rb.useGravity = false;
                rb.freezeRotation = true;
            }

            private void Drop()
            {
                IsPickedUp = false;
                rb.useGravity = true;
                rb.freezeRotation = false;
            }

            private void OnCollisionEnter(Collision col) => Drop();
        }
    }
}
