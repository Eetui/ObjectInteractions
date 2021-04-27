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

            [Header("Throw")]
            [SerializeField] private GameObject throwPanel;
            [SerializeField] private Text throwKeyText;
            [SerializeField] private Text throwText;
            private string throwKey;

            //set info text should be on its own script
            [SerializeField] private Text infoText;

            private void Start()
            {
                throwKey = player.ThrowKey.ToString();
                interactionKey = player.InteractionKey.ToString();
                SetInfoText();
            }

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

            public void UpdateThrowableUI()
            {
                if (player.throwable != null)
                {
                    throwText.text = player.throwable.GetTwhorableText();
                    throwKeyText.text = throwKey;
                    throwPanel.SetActive(true);
                }
                else
                {
                    throwPanel.SetActive(false);
                }
            }

            private void SetInfoText()
            {
                string infoString = $"WASD - Move\nL Shift - Sprint\n{interactionKey} - Interact";
                infoText.text = infoString;
            }
        }
    }
}
