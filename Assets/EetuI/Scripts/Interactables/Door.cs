using System.Collections;
using UnityEngine;

namespace AGP
{
    namespace EetuI
    {
        public class Door : MonoBehaviour
        {
            [Header("Rotation")]
            [SerializeField] internal Vector3 closedRotation = Vector3.zero;
            [SerializeField] internal Vector3 openRotation = new Vector3(0f, -90f, 0f);

            [Header("Position")]
            [SerializeField] internal Vector3 closedPosition;
            [SerializeField] internal Vector3 openPosition = new Vector3(0f, 0f, 0f);

            [Header("Other")]
            [SerializeField] internal float closingDuration = 1.5f;
            [SerializeField] internal bool isDoorOpen = false;
            
            void Start()
            {
                closedPosition = transform.position;
                openPosition += closedPosition;
            }

            public void UseDoor()
            {
                if (isDoorOpen)
                {
                    DoorAction(closedRotation, closedPosition);
                    isDoorOpen = false;
                }
                else if (!isDoorOpen)
                {
                    DoorAction(openRotation, openPosition);
                    isDoorOpen = true;
                }
            }

            private void DoorAction(Vector3 lerpToRotation, Vector3 lerpToPosition)
            {
                StopAllCoroutines();
                StartCoroutine(LerpRotation(Quaternion.Euler(lerpToRotation), closingDuration));
                StartCoroutine(LerpPosition(lerpToPosition, closingDuration));
            }

            private IEnumerator LerpRotation(Quaternion endValue, float duration)
            {
                float time = 0;
                Quaternion startValue = transform.rotation;

                while (time < duration)
                {
                    transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
                    time += Time.deltaTime;
                    yield return null;
                }
                transform.rotation = endValue;
            }

            private IEnumerator LerpPosition(Vector3 targetPosition, float duration)
            {
                float time = 0;
                Vector3 startPosition = transform.position;

                while (time < duration)
                {
                    transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
                    time += Time.deltaTime;
                    yield return null;
                }
                transform.position = targetPosition;
            }
        }
    }
}
