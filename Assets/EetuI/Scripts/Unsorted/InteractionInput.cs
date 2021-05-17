using AGP.EetuI.Events;
using UnityEngine;

namespace AGP
{
    namespace EetuI
    {
        public class InteractionInput : MonoBehaviour
        {

            [SerializeField] private KeyCode interactionKey = KeyCode.F;
            [SerializeField] private KeyCode throwKey = KeyCode.E;

            [Header("Events")]
            [SerializeField] private GameEvent onInteractionPressed;
            [SerializeField] private GameEvent onThrowPressed;

            [Header("KeyCode strings")]
            [SerializeField] private StringSO interactionKeyString;
            [SerializeField] private StringSO throwKeyString;

            private void Awake()
            {
                interactionKeyString.SetValue(interactionKey.ToString());
                throwKeyString.SetValue(throwKey.ToString());
            }

            private void Update()
            {
                if (Input.GetKeyDown(interactionKey))
                {
                    onInteractionPressed?.Invoke();
                }

                if (Input.GetKeyDown(throwKey))
                {
                    onThrowPressed?.Invoke();
                }
            }
        }
    }
}
