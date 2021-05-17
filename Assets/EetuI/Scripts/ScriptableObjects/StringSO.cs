using UnityEngine;

namespace AGP
{
    namespace EetuI
    {
        [CreateAssetMenu(menuName = "Eetu/ScriptableObjects/String", fileName = "New StringSO")]
        public class StringSO : ScriptableObject
        {
            [SerializeField] private string value;

            public string Value { get; }

            public void SetValue(string setValue)
            {
                value = setValue;
            }
        }
    }
}
