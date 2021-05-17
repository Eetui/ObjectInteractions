using UnityEngine;
using AGP.EetuI.Core;
using UnityEngine.UI;

namespace AGP
{
    namespace EetuI
    {
        public class UIThrow : MonoBehaviour
        {
            [SerializeField] private PlayerInteract player;

            [Header("Throw")]
            [SerializeField] private GameObject throwPanel;
            [SerializeField] private Text throwKeyText;
            [SerializeField] private Text throwText;
            private string throwKey;

            private void Start()=> throwKey = player.ThrowKey.ToString();

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
        }
    }
}
