using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AGP
{
    namespace EetuI
    {
        [RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
        public class CollisionSound : MonoBehaviour
        {
            
            [SerializeField] private AudioSource audioSource;
            [SerializeField] private CollisionSoundSettings soundSettings;

            //Clips
            [SerializeField] private List<AudioClip> audioClips;
            private List<AudioClip> usedAudioClips = new List<AudioClip>();

            //Sound manipulation 
            private float soundThreshold;
            private AnimationCurve loudnessCurve;
            private Vector2 pitchVariance = new Vector2(0.5f, 1.1f);

            //For calculating the sound loudness
            private Rigidbody rb;
            private Vector3 velocityBeforePhysicsUpdate;

            private void Awake()
            {
                rb = GetComponent<Rigidbody>();
                if(!audioSource) audioSource = GetComponent<AudioSource>();

                InitializeSettings();
            }

            private void FixedUpdate()
            {
                velocityBeforePhysicsUpdate = rb.velocity;
            }

            public void OnCollisionEnter(Collision col)
            {
                var dot = math.dot(col.contacts[0].normal, -velocityBeforePhysicsUpdate);

                if (velocityBeforePhysicsUpdate.magnitude > soundThreshold)
                {
                    audioSource.volume = loudnessCurve.Evaluate(dot*0.1f);
                    PlayRandomClip();
                }
            }

            public void PlayRandomClip()
            {
                var random = Random.Range(0, audioClips.Count);

                if (usedAudioClips.Count != 0)
                {
                    audioClips.Add(usedAudioClips[0]);
                    usedAudioClips.RemoveAt(0);
                }

                usedAudioClips.Add(audioClips[random]);
                audioSource.pitch = Random.Range(pitchVariance.x, pitchVariance.y);
                audioSource.PlayOneShot(audioClips[random]);
                audioClips.RemoveAt(random);
            }

            private void InitializeSettings()
            {
                soundThreshold = soundSettings.soundThreshold;
                loudnessCurve = soundSettings.loudnessCurve;
                pitchVariance = soundSettings.pitchVariance;

                audioSource.spatialBlend = soundSettings.spatialBlend;
                audioSource.maxDistance = soundSettings.maxDistance;
                audioSource.minDistance = soundSettings.minDistance;
                audioSource.playOnAwake = soundSettings.playOnAwake;
            }
        }
    }
}