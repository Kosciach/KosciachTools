using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace KosciachTools.Tween
{
    public class KosciachTween
    {
        private class Tween
        {
            public Guid Key;
            public IEnumerator Coroutine;
            public float Delay = 0;
        }

        private static KosciachTweenRunner Runner;
        private static Dictionary<Guid, Tween> Tweens = new Dictionary<Guid, Tween>();
        private Tween CurrentTween;


        private KosciachTween()
        {
            if (Runner == null) Runner = new GameObject("KosciachTweenRunner").AddComponent<KosciachTweenRunner>();
        }
        private class KosciachTweenRunner : MonoBehaviour
        {
            private void Start()
            {
                DontDestroyOnLoad(Runner);
            }


            public void RunTween(IEnumerator tweenCoroutine)
            {
                if(tweenCoroutine == null)
                {
                    Debug.LogWarning("KosciachTween - TweenCoroutine is null");
                    return;
                }

                StartCoroutine(tweenCoroutine);
            }
            public void CancelTween(IEnumerator tweenCoroutine)
            {
                if (tweenCoroutine == null)
                {
                    Debug.LogWarning("KosciachTween - TweenCoroutine is null");
                    return;
                }

                StopCoroutine(tweenCoroutine);
            }
        }



        public Guid Run()
        {
            if (CurrentTween != null)
            {
                Runner.RunTween(CurrentTween.Coroutine);
                return CurrentTween.Key;
            }

            Debug.LogWarning("KosciachTween - No active tween to run.");
            return Guid.Empty;
        }
        public KosciachTween SetDelay(float delay)
        {
            CurrentTween.Delay = delay;
            return this;
        }



        public static KosciachTween Position(Transform transform, string name)
        {
            Guid newKey = Guid.NewGuid();
            IEnumerator tweenCoroutine = PositionCoroutine(newKey,  transform, name);

            Tween newTween = new Tween();
            newTween.Key = newKey;
            newTween.Coroutine = tweenCoroutine;
            Tweens.Add(newKey, newTween);

            KosciachTween newKosciachTween = new KosciachTween();
            newKosciachTween.CurrentTween = newTween;
            return newKosciachTween;
        }
        private static IEnumerator PositionCoroutine(Guid newKey, Transform transform, string name)
        {
            Tween currentTween = Tweens[newKey];

            if(currentTween.Delay > 0) yield return new WaitForSeconds(currentTween.Delay);

            Debug.Log(name);
            Tweens.Remove(newKey);
        }
    }
}