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
        KosciachTween.TweenScale(transform, Vector3.zero, 2, null, () =>
        {
            KosciachDelay.Delay(0.5f, () => { KosciachTween.TweenScale(transform, Vector3.one * 5, 3, null, null, TweenEase.EaseOutElastic); });

        }, TweenEase.EaseInOutCubic);
    }

}
