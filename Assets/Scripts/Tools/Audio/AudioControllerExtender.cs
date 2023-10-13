using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KosciachTools.Audio
{
    public class AudioControllerExtender : MonoBehaviour
    {
        private void Start()
        {
            AudioController.Instance.OnSceneEnter();
        }


        public void PlaySoundOnButtonPress(string soundKey)
        {
            AudioController.Instance.PlaySound(soundKey);
        }
    }
}