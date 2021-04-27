using UnityEngine;

namespace AGP
{
    namespace EetuI
    {
        public class ChangeMaterial : MonoBehaviour
        {
            private Material startMaterial;
            [SerializeField] private Material temporaryMaterial;

            private MeshRenderer meshRenderer;

            private bool hasMaterialChanged = false;

            private void Start()
            {
                meshRenderer = GetComponent<MeshRenderer>();
                startMaterial = meshRenderer.material;
            }

            public void SetStartingMaterial(Material material)
            {
                startMaterial = material;
            }

            public void ChangeMaterials()
            {
                if (hasMaterialChanged)
                {
                    meshRenderer.material = startMaterial;
                    hasMaterialChanged = false;

                }
                else
                {
                    meshRenderer.material = temporaryMaterial;
                    hasMaterialChanged = true;
                }
            }
        }
    }
}
