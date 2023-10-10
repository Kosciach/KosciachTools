using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{


    private AudioSettings _audioSettings = new AudioSettings();


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }



    public void ChangeMusicVolume()
    {

    }
    public void ChangeSoundsVolume()
    {

    }
}