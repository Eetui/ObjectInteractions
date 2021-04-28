using ObjectInteractionGame.EetuI.Core;
using UnityEngine;

namespace ObjectInteractionGame
{
    namespace EetuI
    {
        public class CubeColor : MonoBehaviour, IInteractable
        {
            private MeshRenderer meshRenderer;

            void Start() => meshRenderer = GetComponent<MeshRenderer>();

            private void ChangeColor()
            {
                var randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                meshRenderer.material.color = randomColor;
            }

            public string GetInteractionText() => "Change Color";

            public void Interact() => ChangeColor();
        }
    }
}
