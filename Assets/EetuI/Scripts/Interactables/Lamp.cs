using UnityEngine;
using AGP.EetuI.Core;

namespace AGP
{
    namespace EetuI
    {
        public class Lamp : MonoBehaviour, IInteractable
        {
            [SerializeField] private GameObject lampLight;
            private bool isLightOn = false;

            public string GetInteractionText() => isLightOn ? "Turn Light Off" : "Turn Light On";
            
            public void Interact()
            {
                if (isLightOn)
                {
                    isLightOn = false;
                    lampLight.SetActive(false);
                }
                else
                {
                    isLightOn = true;
                    lampLight.SetActive(true);
                }
            }
        }
    }
}
