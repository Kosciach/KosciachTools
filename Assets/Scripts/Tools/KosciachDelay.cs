using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KosciachDelay
{
    private static Dictionary<GameObject, List<IEnumerator>> _delays = new Dictionary<GameObject, List<IEnumerator>>();
    public static Dictionary<GameObject, List<IEnumerator>> Delays { get { return _delays; } }



    private class DelayRunner : MonoBehaviour
    {
        private static DelayRunner _instance;
        public static DelayRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject delayGameObject = new GameObject("DelayRunner");
                    _instance = delayGameObject.AddComponent<DelayRunner>();
                    DontDestroyOnLoad(delayGameObject);
                }
                return _instance;
            }
        }
    }

    public static void Delay(GameObject id, float delayTime, Action callback)
    {
        if (!_delays.ContainsKey(id)) _delays[id] = new List<IEnumerator>();

        IEnumerator delay = ExecuteWithDelay(id, delayTime, callback);
        _delays[id].Add(delay);
        DelayRunner.Instance.StartCoroutine(delay);
    }
    private static IEnumerator ExecuteWithDelay(GameObject id, float delayTime, Action callback)
    {
        yield return new WaitForSeconds(delayTime);

        if (_delays.ContainsKey(id))
        {
            callback();
            _delays[id].RemoveAt(0);
        }
    }

    public static void CancelDelay(GameObject id)
    {
        if (!_delays.ContainsKey(id)) return;

        for(int i=0; i< _delays[id].Count; i++)
            DelayRunner.Instance.StopCoroutine(_delays[id][i]);

        _delays.Remove(id);
    }
}