using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Audio
{
    /// <summary>
    /// This script handles slider changes to change the volume.
    /// </summary>

    public class VolumeSlider : MonoBehaviour
    {
        public AudioMixer audioMixer;
        public Slider volumeSlider;

        private void Start()
        {
            float savedVolume = PlayerPrefs.GetFloat("MyExposedParam", 0.75f);
            volumeSlider.value = savedVolume;
            SetVolume(savedVolume);
        }

        public void SetVolume(float volume)
        {
            if (volume <= 40f)
            {
                audioMixer.SetFloat("MyExposedParam", -80f);
            }
            else
            {
                audioMixer.SetFloat("MyExposedParam", Mathf.Log10(volume) * 20);
            }

            PlayerPrefs.SetFloat("MyExposedParam", volume);
        }
    }
}