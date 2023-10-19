using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace KosciachTools.Audio
{
    public class AudioController : MonoBehaviour
    {
        public static AudioController Instance;

        [Header("====References====")]
        [SerializeField] AudioSource _musicSource;
        [SerializeField] SoundsSourcesHolder _soundSources;
        [Space(5)]
        [SerializeField] Slider _musicSlider;
        [SerializeField] Slider _soundsSlider;


        [SerializeField] AudioSettings _audioSettings = new AudioSettings();


        private string _savePath => Application.dataPath + "/AudioSettings.json";
        private const float _defaultVolume = 0.5f;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else Destroy(gameObject);
        }



        public void OnSceneEnter(Slider musicSlider, Slider soundsSlider)
        {
            AssignSliders(musicSlider, soundsSlider);
            HandleSettingsFile();
            SetVolume();
            UpdateSliders();
        }
        private void AssignSliders(Slider musicSlider, Slider soundsSlider)
        {
            _musicSlider = musicSlider;
            _soundsSlider = soundsSlider;
        }
        private void HandleSettingsFile()
        {
            if (File.Exists(_savePath)) LoadSettings();
            else
            {
                _audioSettings.MusicVolume = _defaultVolume;
                _audioSettings.SoundsVolume = _defaultVolume;
                SaveSettings();
            }
        }
        private void SetVolume()
        {
            if (_musicSource != null) _musicSource.volume = _audioSettings.MusicVolume;
            _soundSources.SetVolume(_audioSettings.SoundsVolume);
        }
        private void UpdateSliders()
        {
            if (_musicSlider != null)
            {
                _musicSlider.value = _audioSettings.MusicVolume;
                _musicSlider.onValueChanged.AddListener(ChangeMusicValue);
            }
            if (_soundsSlider != null)
            {
                _soundsSlider.value = _audioSettings.SoundsVolume;
                _soundsSlider.onValueChanged.AddListener(ChangeSoundsValue);
            }
        }



        private void ChangeMusicValue(float volume)
        {
            _audioSettings.MusicVolume = volume;
            _musicSource.volume = volume;

            SaveSettings();
        }
        private void ChangeSoundsValue(float volume)
        {
            _audioSettings.SoundsVolume = volume;
            _soundSources.SetVolume(volume);

            SaveSettings();
        }

        public void PlaySound(string soundName)
        {
            if (_soundSources.KeyExists(soundName)) _soundSources.GetSound(soundName).Play();
        }
        public void SpawnSound(Vector3 pos, bool local, string soundName)
        {
            if (!_soundSources.KeyExists(soundName)) return;


            GameObject soundGameObject = new GameObject("Sound_" + soundName);

            if (local) soundGameObject.transform.localPosition = pos;
            else soundGameObject.transform.position = pos;

            AudioSource soundGameObjectAudioSource = soundGameObject.AddComponent<AudioSource>();
            soundGameObjectAudioSource = _soundSources.GetSound(soundName);

            Destroy(soundGameObject, 5);
        }


        private void SaveSettings()
        {
            string savedSettings = JsonUtility.ToJson(_audioSettings);
            File.WriteAllText(_savePath, savedSettings);
        }
        private void LoadSettings()
        {
            string loadedSettings = File.ReadAllText(_savePath);
            _audioSettings = JsonUtility.FromJson<AudioSettings>(loadedSettings);
        }
    }
}