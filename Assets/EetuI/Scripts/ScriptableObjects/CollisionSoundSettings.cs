using UnityEngine;

namespace AGP
{
    namespace EetuI
    {
        [CreateAssetMenu(menuName = "Eetu/ScriptableObjects/CollisionSound Settings", fileName = "New CollisionSound Settings")]
        public class CollisionSoundSettings : ScriptableObject
        {

            [Header("Sound Settings")] public float soundThreshold = 1f;
            public AnimationCurve loudnessCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
            [Tooltip("X: min, Y: max")]public Vector2 pitchVariance = new Vector2(0.5f, 1.1f);

            [Header("Audio Source Settings")]
            [Range(0f, 1f)] public float spatialBlend = 0.95f;

            [Range(10f, 1000f)] public float maxDistance = 100f;
            [Range(1f, 50f)] public float minDistance = 2f;
            public bool playOnAwake = false;
        }
    }
}
