using ObjectInteractionGame.EetuI.Events;
using UnityEngine;

namespace ObjectInteractionGame
{
    namespace EetuI
    {
        public class Hoop : MonoBehaviour
        {
            [SerializeField] private GameEvent gameEvent;

            private void OnTriggerEnter(Collider col)
            {
                gameEvent?.Invoke();
            }
        }
    }
}
