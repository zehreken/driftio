using UnityEngine;

namespace cln.Sources.Services
{
    public enum Clip
    {
        Jump,
        Grounded,
        Die,
    }

    public class AudioService : IService
    {
        private AudioDictionary _audioDictionary;
        private readonly AudioSource _audioSource;
        public bool IsMuted { private set; get; }

        public AudioService()
        {
            _audioSource = new GameObject("AudioService").AddComponent<AudioSource>();
            IsMuted = PlayerPrefs.GetInt(Consts.MuteKey, 1) == 1;
        }

        public void Initialize()
        {
            _audioDictionary = Resources.Load<AudioDictionary>("AudioDictionary");
        }

        public void Play(Clip name)
        {
            if (IsMuted)
                return;

            _audioSource.PlayOneShot(_audioDictionary.GetAudioClips()[name]);
        }

        public bool ToggleSound()
        {
            IsMuted = !IsMuted;
            PlayerPrefs.SetInt(Consts.MuteKey, IsMuted ? 1 : 0);

            return IsMuted;
        }
    }
}