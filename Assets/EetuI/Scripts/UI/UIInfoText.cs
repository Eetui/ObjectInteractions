using AGP.EetuI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace AGP
{
    namespace EetuI
    {
        public class UIInfoText : MonoBehaviour
        {
            [SerializeField] private PlayerInteract player;
            [SerializeField] private Text infoText;

            private void Start() => SetInfoText();

            private void SetInfoText()
            {
                string infoString = $"WASD - Move\nL Shift - Sprint\n{player.InteractionKey.ToString()} - Interact";

                infoText.text = infoString;
            }
        }
    }
}
