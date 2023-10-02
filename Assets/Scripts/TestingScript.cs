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
        KosciachTween.TweenPosX(transform, 5, 2, true);
        KosciachTween.TweenPosY(transform, 5, 2, true);
        KosciachTween.TweenPosZ(transform, 5, 2, true);
    }

}
