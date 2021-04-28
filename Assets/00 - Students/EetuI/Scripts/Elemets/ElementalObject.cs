using UnityEngine;
using System.Collections.Generic;

namespace ObjectInteractionGame
{
    namespace EetuI
    {
        namespace Element
        {
            [CreateAssetMenu(menuName = "Eetu/ElementalObject", fileName = "ElementalObject")]
            public class ElementalObject : ScriptableObject
            {
                public List<ElementalObject> ElementsToInteractWith = new List<ElementalObject>();
            }
        }
    }
}
