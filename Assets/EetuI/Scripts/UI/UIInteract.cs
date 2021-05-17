using UnityEngine;
using AGP.EetuI.Core;
using UnityEngine.UI;

namespace AGP
{
    namespace EetuI
    {
        public class UIInteract : MonoBehaviour
        {
            [SerializeField] private PlayerInteract player;

            [Header("Interaction")]
            [SerializeField] private GameObject interactPanel;
            [SerializeField] private Text interactKeyText;
            [SerializeField] private Text interactionText;
            private string interactionKey;

            private void Start() => interactionKey = player.InteractionKey.ToString();

            public void UpdateInteractionUI()
            {
                if (player.interactable != null)
                {
                    interactionText.text = player.interactable.GetInteractionText();
                    interactKeyText.text = interactionKey;
                    interactPanel.SetActive(true);
                }
                else
                {
                    interactPanel.SetActive(false);
                }
            }
        }
    }
}
