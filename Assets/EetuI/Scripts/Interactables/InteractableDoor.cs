using AGP.EetuI.Core;

namespace AGP
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
