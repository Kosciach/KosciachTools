using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace KosciachTools
{
    public static class KosciachTween
    {
        //TweenNumbers
        public static IEnumerator TweenFloat(float from, float to, float tweenTime, Action<float> onUpdate, Action onFinish = null)
        {
            if(tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpFloat(from, to, tweenTime, onUpdate, onFinish);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpFloat(float from, float to, float tweenTime, Action<float> onUpdate, Action onFinish)
        {
            float timeElapsed = 0;

            while(timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float lerpValue = Mathf.Lerp(from, to, time);
                onUpdate?.Invoke(lerpValue);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            onUpdate?.Invoke(to);
            onFinish?.Invoke();
        }


        //TweenPos
        public static IEnumerator TweenPos(Transform transform, Vector3 target, float tweenTime, Action onUpdate = null, Action onFinish = null)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpPos(transform, target, tweenTime, onUpdate, onFinish);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpPos(Transform transform, Vector3 target, float tweenTime, Action onUpdate, Action onFinish)
        {
            Vector3 startPos = transform.position;
            float timeElapsed = 0;
            while(timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                transform.position = Vector3.Lerp(startPos, target, time);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        public static IEnumerator TweenPosLocal(Transform transform, Vector3 target, float tweenTime, Action onUpdate = null, Action onFinish = null)
        {
            if(tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpPosLocal(transform, target, tweenTime, onUpdate, onFinish);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpPosLocal(Transform transform, Vector3 target, float tweenTime, Action onUpdate, Action onFinish)
        {
            Vector3 startPos = transform.localPosition;
            float timeElapsed = 0;
            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                transform.localPosition = Vector3.Lerp(startPos, target, time);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }


        //TweenRot
        public static IEnumerator TweenRotEuler(Transform transform, Vector3 target, float tweenTime, Action onUpdate = null, Action onFinish = null)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpRotEuler(transform, target, tweenTime, onUpdate, onFinish);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpRotEuler(Transform transform, Vector3 target, float tweenTime, Action onUpdate, Action onFinish)
        {
            Vector3 startEuler = transform.eulerAngles;
            float timeElapsed = 0;
            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                transform.eulerAngles = Vector3.Lerp(startEuler, target, time);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.eulerAngles = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        public static IEnumerator TweenRotEulerLocal(Transform transform, Vector3 target, float tweenTime, Action onUpdate = null, Action onFinish = null)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpRotEulerLocal(transform, target, tweenTime, onUpdate, onFinish);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpRotEulerLocal(Transform transform, Vector3 target, float tweenTime, Action onUpdate, Action onFinish)
        {
            Vector3 startEuler = transform.localEulerAngles;
            float timeElapsed = 0;
            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                transform.localEulerAngles = Vector3.Lerp(startEuler, target, time);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localEulerAngles = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }

        public static IEnumerator TweenRotQuaternion(Transform transform, Quaternion target, float tweenTime, Action onUpdate = null, Action onFinish = null)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpRotQuaternion(transform, target, tweenTime, onUpdate, onFinish);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpRotQuaternion(Transform transform, Quaternion target, float tweenTime, Action onUpdate, Action onFinish)
        {
            Quaternion startQuaternion = transform.rotation;
            float timeElapsed = 0;
            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                transform.rotation = Quaternion.Lerp(startQuaternion, target, time);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.rotation = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        public static IEnumerator TweenRotQuaternionLocal(Transform transform, Quaternion target, float tweenTime, Action onUpdate = null, Action onFinish = null)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpRotQuaternionLocal(transform, target, tweenTime, onUpdate, onFinish);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpRotQuaternionLocal(Transform transform, Quaternion target, float tweenTime, Action onUpdate, Action onFinish)
        {
            Quaternion startQuaternion = transform.localRotation;
            float timeElapsed = 0;
            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                transform.localRotation = Quaternion.Lerp(startQuaternion, target, time);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localRotation = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }


        //TweenVectors
        public static IEnumerator TweenVector2(Vector2 from, Vector2 to, float tweenTime, Action<Vector2> onUpdate, Action onFinish = null)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpVector2(from, to, tweenTime, onUpdate, onFinish);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpVector2(Vector2 from, Vector2 to, float tweenTime, Action<Vector2> onUpdate, Action onFinish)
        {
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                Vector2 lerpValue = Vector2.Lerp(from, to, time);
                onUpdate?.Invoke(lerpValue);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            onUpdate?.Invoke(to);
            onFinish?.Invoke();
        }
        public static IEnumerator TweenVector3(Vector3 from, Vector3 to, float tweenTime, Action<Vector3> onUpdate, Action onFinish = null)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpVector3(from, to, tweenTime, onUpdate, onFinish);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpVector3(Vector3 from, Vector3 to, float tweenTime, Action<Vector3> onUpdate, Action onFinish)
        {
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                Vector3 lerpValue = Vector3.Lerp(from, to, time);
                onUpdate?.Invoke(lerpValue);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            onUpdate?.Invoke(to);
            onFinish?.Invoke();
        }





        //TweenUtility
        public static void CancelTween(IEnumerator tween)
        {
            if(tween == null)
            {
                Debug.LogWarning("KosciachTween - tween is null!");
                return;
            }
            KosciachTweenRunner.Instance.StopCoroutine(tween);
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