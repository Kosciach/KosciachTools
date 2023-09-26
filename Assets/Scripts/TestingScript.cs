using KosciachTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{

    private void Awake()
    {
        float elo = 0;
        KosciachTween.Number(elo, 10, 1, (float val) =>
        {
            elo = val;
            Debug.Log(elo);
        });
    }
}
