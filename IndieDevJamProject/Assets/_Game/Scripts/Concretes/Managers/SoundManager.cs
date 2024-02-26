using UnityEngine;
using UnityEngine.UI;

namespace SnaileyGame.Managers
{
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clickButton;
        [SerializeField] private AudioClip bgmusic;
        [SerializeField] private Slider volumeSlider;
        private void Awake()
        {
            ApplySingleton(this);
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey("musicVolume"))
            {
                PlayerPrefs.SetFloat("musicVolume", 1);
                Load();
            }
            else
            {
                Load();
            }
            
        }

        public void PlayClickSound()
        {
            audioSource.PlayOneShot(clickButton);
        }

        public void ChangeVolume()
        {
            if(volumeSlider)
                AudioListener.volume = volumeSlider.value;
        }

        public void Load()
        {
            if(volumeSlider)
                volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        }
        
        public void Save()
        {
            if(volumeSlider)
             PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        }
    }
}
