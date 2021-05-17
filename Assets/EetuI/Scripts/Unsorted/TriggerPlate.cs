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
            [SerializeField] private bool useDelay;
            [SerializeField] private float triggerDelay;
            [SerializeField] private bool usePickableObjectsOnly;
            [Range(1, 10)] [SerializeField] private int itemsNeeded = 2;


            [Header("Trigger Collider Settings")]
            [SerializeField] private Vector3 hitColliderHalfSize;
            [SerializeField] private Vector3 hitColliderOffset;
            [SerializeField] private bool showGizmos;

            private bool canBeActivated;
            private bool lastFrameCanBeActivated;
            private bool timeCanBeAdded;
            private bool stateHasChanged;

            private bool triggered;
            private float timer;

            private void Update()
            {
                if (triggerOnlyOnce && triggered) return;

                var colliders = ColliderBox();

                if (colliders.Length == itemsNeeded) canBeActivated = true;
                else canBeActivated = false;

                if (lastFrameCanBeActivated != canBeActivated)
                {
                    stateHasChanged = !stateHasChanged;

                    if (usePickableObjectsOnly)
                    {
                        timeCanBeAdded = CheckForPickableObjects(colliders);

                        if (timeCanBeAdded && !useDelay) Trigger();
                    }
                    else
                    {
                        if (!useDelay) Trigger();
                        timeCanBeAdded = true;
                    }
                }
                else if (useDelay && stateHasChanged && timeCanBeAdded)
                {
                    timer += Time.deltaTime;
                    if (timer > triggerDelay) Trigger();
                }
                else timer = 0;

                lastFrameCanBeActivated = canBeActivated;
            }

            private bool CheckForPickableObjects(Collider[] colliders)
            {
                bool pickableObjectsFound = false;

                for (int i = 0; i < colliders.Length; i++)
                {
                    pickableObjectsFound = false;

                    if (!colliders[i].TryGetComponent(out PickableObject pickableObject)) break;
                    else pickableObjectsFound = true;

                }
                return pickableObjectsFound;
            }

            private Collider[] ColliderBox()
            {
                return Physics.OverlapBox(transform.position + hitColliderOffset, hitColliderHalfSize, Quaternion.identity, -1);
            }

            private void Trigger()
            {
                gameEventToTrigger?.Invoke();
                triggered = true;
                stateHasChanged = false;
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
