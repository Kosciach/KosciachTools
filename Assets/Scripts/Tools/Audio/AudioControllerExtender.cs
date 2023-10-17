using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KosciachTools.Audio
{
    public class AudioControllerExtender : MonoBehaviour
    {
        [Header("====Sliders====")]
        [SerializeField] Slider _musicSlider;
        [SerializeField] Slider _soundsSlider;


        private void Start()
        {
            AudioController.Instance.OnSceneEnter(_musicSlider, _soundsSlider);
        }


        public void PlaySoundOnButtonPress(string soundKey)
        {
            AudioController.Instance.PlaySound(soundKey);
        }
    }
}