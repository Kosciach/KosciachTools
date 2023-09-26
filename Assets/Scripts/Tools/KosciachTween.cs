using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace KosciachTools
{
    public static class KosciachTween
    {
        public static void Number(float from, float to, float tweenTime, Action<float> onUpdate)
        {
            KosciachTweenRunner.Instance.StartCoroutine(NumberLerp(from, to, tweenTime, onUpdate));
        }
        private static IEnumerator NumberLerp(float from, float to, float tweenTime, Action<float> onUpdate)
        {
            float timeElapsed = 0;

            while(timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float lerpValue = Mathf.Lerp(from, to, time);
                onUpdate(lerpValue);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            onUpdate(to);
        }












        private class KosciachTweenRunner : MonoBehaviour
        {
            private static KosciachTweenRunner _instance;
            public static KosciachTweenRunner Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        GameObject tweenGameObject = new GameObject("KosciachTweenRunner");
                        _instance = tweenGameObject.AddComponent<KosciachTweenRunner>();
                        DontDestroyOnLoad(tweenGameObject);
                    }
                    return _instance;
                }
            }
        }
    }
}