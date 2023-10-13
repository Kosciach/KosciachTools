using KosciachTools;
using KosciachTools.Delay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingScript2 : MonoBehaviour
{
    private void Awake()
    {
        KosciachDelay.Delay(2, Test);
    }

    private void Test()
    {
        SceneManager.LoadScene("Scene1");
    }
}
