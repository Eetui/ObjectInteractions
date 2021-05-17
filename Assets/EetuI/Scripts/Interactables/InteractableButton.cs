using AGP.EetuI.Core;
using AGP.EetuI.Events;
using UnityEngine;

namespace AGP
{
    public class InteractableButton : MonoBehaviour, IInteractable
    {
        [SerializeField] private string defaultText;
        [SerializeField] private string temporaryText;
        [SerializeField] private GameEvent gameEvent;

        private bool hasBeenInteracted;

        public string GetInteractionText() => hasBeenInteracted ? temporaryText : defaultText;

        public void Interact()
        {
            if (hasBeenInteracted)
            {
                hasBeenInteracted = false;
                gameEvent?.Invoke();

            }
            else
            {
                hasBeenInteracted = true;
                gameEvent?.Invoke();
            }
        }
    }
}
