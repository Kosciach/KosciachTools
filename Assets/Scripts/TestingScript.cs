using KosciachTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    [SerializeField] Vector3 a;
    [SerializeField] Vector3 b;


    private void Awake()
    {
        KosciachDelay.Delay(gameObject, 3, Test);
    }

    private void Test()
    {

    }
}
