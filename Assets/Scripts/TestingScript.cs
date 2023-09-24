using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{

    private void Awake()
    {
        KosciachDelay.Delay(gameObject, 2, () =>
        {
            Debug.Log("Hello1!");
        });
        KosciachDelay.Delay(gameObject, 4, () =>
        {
            Debug.Log("Hello2!");
        });
    }
}
