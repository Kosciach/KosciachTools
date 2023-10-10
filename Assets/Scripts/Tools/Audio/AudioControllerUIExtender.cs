using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerUIExtender : MonoBehaviour
{
    private AudioController _audioController;

    private void Awake()
    {
        _audioController = GetComponent<AudioController>();
    }




}
