using KosciachTools.Delay;
using KosciachTools.Tween;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingScript : MonoBehaviour
{
    [SerializeField] int _tweenCount;


    private void Awake()
    {
        KosciachDelay.Delay(1, Test);
    }

    private void Test()
    {
        SceneManager.LoadScene("Scene2");
    }

    private void Update()
    {
        _tweenCount = KosciachTween.GetTweensCount();
    }
}
