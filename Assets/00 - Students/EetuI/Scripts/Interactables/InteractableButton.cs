using ObjectInteractionGame.EetuI.Core;
using ObjectInteractionGame.EetuI.Events;
using UnityEngine;

namespace ObjectInteractionGame
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
