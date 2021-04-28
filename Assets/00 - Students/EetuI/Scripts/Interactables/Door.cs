using System.Collections;
using UnityEngine;

namespace ObjectInteractionGame
{
    namespace EetuI
    {
        public class Door : MonoBehaviour
        {
            public Vector3 closedPosition = Vector3.zero;
            public Vector3 openPosition = new Vector3(0, -90f, 0);
            public float closingDuration = 1.5f;
            public bool isDoorOpen = false;

            public void UseDoor()
            {
                if (isDoorOpen)
                {
                    DoorAction(closedPosition);
                    isDoorOpen = false;
                }
                else if (!isDoorOpen)
                {
                    DoorAction(openPosition);
                    isDoorOpen = true;
                }
            }

            private void DoorAction(Vector3 lerpToPosition)
            {
                StopAllCoroutines();
                StartCoroutine(Lerp(Quaternion.Euler(lerpToPosition), closingDuration));
            }

            private IEnumerator Lerp(Quaternion endValue, float duration)
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
        }
    }
}
