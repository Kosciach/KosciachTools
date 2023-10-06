using KosciachTools.Delay;
using KosciachTools.Tween;
using System.Collections;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    public Vector3 a;


    private void Awake()
    {
        KosciachDelay.Delay(1, Test);
    }

    private void Test()
    {
        KosciachTween.Vector3D(a, Vector3.one*5, 2).SetOnUpdate((Vector3 val) =>
        {
            a = val;
        }).Run();
    }
}
