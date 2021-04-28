using ObjectInteractionGame.EetuI.Core;

namespace ObjectInteractionGame
{
    namespace EetuI
    {
        public class InteractableDoor : Door, IInteractable
        {
            public string GetInteractionText() => isDoorOpen ? "Open Door" : "Close Door";

            public void Interact() => UseDoor();
        }
    }
}
