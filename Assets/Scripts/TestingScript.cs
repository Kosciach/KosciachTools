using KosciachTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    private void Awake()
    {
        KosciachDelay.Delay(3, Test);
    }

    private void Test()
    {
        KosciachTween.TweenPos(transform, transform.forward * 5, 3, null, null, TweenEase.EaseInOutSine);
    }

}
