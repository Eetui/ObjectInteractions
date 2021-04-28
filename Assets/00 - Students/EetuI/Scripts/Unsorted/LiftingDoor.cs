using System.Collections;
using UnityEngine;

namespace ObjectInteractionGame
{
    namespace EetuI
    {
        public class LiftingDoor : MonoBehaviour
        {
            [SerializeField] private float yAxisTargetOffset;

            public void OpenDoor() => StartCoroutine(Lerp(new Vector3(transform.position.x, transform.position.y + yAxisTargetOffset, transform.position.z), 10));

            private IEnumerator Lerp(Vector3 target, float duration)
            {
                float time = 0;
                Vector3 startPosition = transform.position;

                while (time < duration)
                {
                    transform.position = Vector3.Lerp(startPosition, target, time / duration);
                    time += Time.deltaTime;
                    yield return null;
                }
                transform.position = target;
            }
        }
    }
}
