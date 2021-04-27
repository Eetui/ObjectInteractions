using AGP.EetuI.Events;
using UnityEngine;

namespace AGP
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
