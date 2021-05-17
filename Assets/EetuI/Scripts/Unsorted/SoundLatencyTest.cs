using UnityEngine;

namespace AGP
{
    public class SoundLatencyTest : MonoBehaviour
    {
        public AudioSource audioSource;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                audioSource.Play();
            }
        }
    }
}
