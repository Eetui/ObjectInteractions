using UnityEngine;
using UnityEngine.Events;

namespace ObjectInteractionGame
{
    namespace EetuI
    {
        namespace Events
        {
            public class GameEventListener : MonoBehaviour
            {
                [SerializeField] private GameEvent gameEvent;
                [SerializeField] private UnityEvent unityEvent;

                private void Awake() => gameEvent.AddListener(this);

                private void OnDestroy() => gameEvent.RemoveListener(this);

                public void TriggerEvent() => unityEvent?.Invoke();
            }
        }
    }
}
