using KosciachTools.Delay;
using KosciachTools.Tween;
using KosciachTools.Tween2;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TestingScript : MonoBehaviour
{
    private void Awake()
    {
        KosciachDelay.Delay(3, Test);
    }

    private void Test()
    {

    }

}
