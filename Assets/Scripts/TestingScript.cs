using KosciachTools.Delay;
using KosciachTools.Tween;
using System.Collections;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    private void Awake()
    {
        KosciachDelay.Delay(1, Test);
    }

    private void Test()
    {
        KosciachTween.Position(transform, "elo1").Run();
        KosciachTween.Position(transform, "elo2").Run();
    }

}
