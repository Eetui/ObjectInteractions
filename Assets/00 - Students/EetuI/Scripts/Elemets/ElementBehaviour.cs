using UnityEngine;
using UnityEngine.Events;

namespace ObjectInteractionGame
{
    namespace EetuI
    {
        namespace Element
        {
            public class ElementBehaviour : MonoBehaviour
            {
                public ElementalObject elementalObject;
                public UnityEvent OnElementCollision;

                public void SetElement(ElementalObject _elementalObject)
                {
                    elementalObject = _elementalObject;
                }

                public virtual void OnCollisionEnter(Collision col)
                {
                    if (col.gameObject.TryGetComponent(out ElementBehaviour colElement))
                    {
                        if (elementalObject.ElementsToInteractWith.Contains(colElement.elementalObject))
                        {
                            OnElementCollision?.Invoke();
                        }
                    }
                }
            }
        }
    }
}
