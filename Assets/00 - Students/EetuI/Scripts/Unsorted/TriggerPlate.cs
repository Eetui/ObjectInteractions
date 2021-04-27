using AGP.EetuI.Events;
using UnityEngine;

namespace AGP
{
    namespace EetuI
    {
        public class TriggerPlate : MonoBehaviour
        {
            [Header("Trigger Settings")]
            [SerializeField] private GameEvent gameEventToTrigger;
            [SerializeField] private bool triggerOnlyOnce;
            [SerializeField] private bool useMultipleItems;
            [SerializeField] private int itemsNeededToTrigger;
            [Tooltip("Only works if multiple items is enabled")]
            [SerializeField] private float triggerDelay;

            [Header("Trigger Collider Settings")]
            [SerializeField] private Vector3 hitColliderHalfSize;
            [SerializeField] private Vector3 hitColliderOffset;
            [SerializeField] private bool showGizmos;

            private bool triggered;
            private float timer;

            private bool somethingOnThePlate;
            private bool lastFrameSomethingOnThePlate;

            private void Update()
            {
                if (triggered && triggerOnlyOnce) return;

                Collider[] hitColliders = Physics.OverlapBox(transform.position + hitColliderOffset, hitColliderHalfSize, Quaternion.identity, -1);

                if (useMultipleItems) UseMultipleItems(hitColliders);
                else SomethingOnThePlate(hitColliders.Length);
            }

            private void SomethingOnThePlate(int hitCollidersLenght)
            {
                if (hitCollidersLenght > 0) somethingOnThePlate = true;
                else somethingOnThePlate = false;

                if (lastFrameSomethingOnThePlate != somethingOnThePlate) Trigger();

                lastFrameSomethingOnThePlate = somethingOnThePlate;
            }

            private void UseMultipleItems(Collider[] hitColliders)
            {
                if (hitColliders.Length != itemsNeededToTrigger) return;

                bool timeCanBeAdded = false;

                for (int i = 0; i < hitColliders.Length; i++)
                {
                    if (!hitColliders[i].TryGetComponent(out PickableObject pickableObject)) break;
                    if (!pickableObject.IsPickedUp) timeCanBeAdded = true;
                    else break;
                }

                if (timeCanBeAdded) timer += Time.deltaTime;
                else timer = 0;

                if (timer > triggerDelay) Trigger();
            }

            private void Trigger()
            {
                gameEventToTrigger.Invoke();
                triggered = true;
            }

            private void OnDrawGizmos()
            {
                if (showGizmos)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireCube(transform.position + hitColliderOffset, hitColliderHalfSize * 2);
                }
            }
        }
    }
}
