using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KosciachTools.Audio
{
    [System.Serializable]
    public class SoundsSourcesHolder
    {
        [SerializeField] List<string> _keys = new List<string>();
        [SerializeField] List<AudioSource> _soundsSources = new List<AudioSource>();

        public bool KeyExists(string key)
        {
            return _keys.Contains(key);
        }
        public AudioSource GetSound(string key)
        {
            int keyIndex = _keys.IndexOf(key);
            return _soundsSources[keyIndex];
        }

        public void SetVolume(float volume)
        {
            foreach (AudioSource source in _soundsSources) source.volume = volume;
        }
    }
}