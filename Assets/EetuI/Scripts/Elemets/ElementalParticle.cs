using AGP.EetuI.Element;
using UnityEngine;

namespace AGP
{
    namespace EetuI
    {
        public class ElementalParticle : ElementBehaviour
        {
            [SerializeField] private ParticleSystem particle;

            public void UpdateParticleSystemStatus()
            {
                if (particle.isPlaying)
                {
                    particle.Stop();
                }
                else
                {
                    particle.Play();
                }
            }

            private void OnParticleCollision(GameObject other)
            {
                if (other.TryGetComponent(out ElementBehaviour otherElement))
                {
                    if (otherElement.elementalObject.ElementsToInteractWith.Contains(elementalObject))
                    {
                        otherElement.OnElementCollision?.Invoke();
                    }
                }
            }

            public override void OnCollisionEnter(Collision col)
            {

            }
        }
    }
}
