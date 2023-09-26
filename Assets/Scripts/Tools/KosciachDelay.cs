using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KosciachTools
{
    public static class KosciachDelay
    {
        private static Dictionary<GameObject, List<IEnumerator>> _delays = new Dictionary<GameObject, List<IEnumerator>>();
        public static Dictionary<GameObject, List<IEnumerator>> Delays { get { return _delays; } }

        private class KosciachDelayRunner : MonoBehaviour
        {
            private static KosciachDelayRunner _instance;
            public static KosciachDelayRunner Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        GameObject delayGameObject = new GameObject("KosciachDelayRunner");
                        _instance = delayGameObject.AddComponent<KosciachDelayRunner>();
                        DontDestroyOnLoad(delayGameObject);
                    }
                    return _instance;
                }
            }
        }



        public static void Delay(GameObject gameObject, float delayTime, Action callback)
        {
            if (gameObject == null)
            {
                Debug.LogWarning("Delay: GameObject is null.");
                return;
            }

            if (!_delays.ContainsKey(gameObject))
                _delays[gameObject] = new List<IEnumerator>();

            IEnumerator delay = ExecuteWithDelay(gameObject, delayTime, callback);
            _delays[gameObject].Add(delay);
            KosciachDelayRunner.Instance.StartCoroutine(delay);
        }

        private static IEnumerator ExecuteWithDelay(GameObject gameObject, float delayTime, Action callback)
        {
            yield return new WaitForSeconds(delayTime);

            if (_delays.ContainsKey(gameObject))
            {
                callback();
                _delays[gameObject].RemoveAt(0);
            }
        }

        public static void CancelDelay(GameObject gameObject)
        {
            if (gameObject == null)
            {
                Debug.LogWarning("CancelDelay: GameObject is null.");
                return;
            }

            if (!_delays.ContainsKey(gameObject)) return;

            foreach (IEnumerator delay in _delays[gameObject])
                KosciachDelayRunner.Instance.StopCoroutine(delay);

            _delays.Remove(gameObject);
        }
    }
}