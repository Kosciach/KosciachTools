using System.Collections;
using UnityEngine;
using System;

namespace KosciachTools
{
    public static class KosciachTween
    {
        //TweenNumbers
        public static IEnumerator TweenNumber(float from, float to, float tweenTime, Action<float> onUpdate, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if(tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpNumber(from, to, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpNumber(float from, float to, float tweenTime, Action<float> onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            float timeElapsed = 0;

            while(timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                float lerpValue = Mathf.LerpUnclamped(from, to, timeWithEase);
                onUpdate?.Invoke(lerpValue);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            onUpdate?.Invoke(to);
            onFinish?.Invoke();
        }


        //TweenPos
        public static IEnumerator TweenPos(Transform transform, Vector3 target, float tweenTime, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpPos(transform, target, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpPos(Transform transform, Vector3 target, float tweenTime, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            Vector3 startPos = transform.position;
            float timeElapsed = 0;

            while(timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                transform.position = Vector3.LerpUnclamped(startPos, target, timeWithEase);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        public static IEnumerator TweenPosLocal(Transform transform, Vector3 target, float tweenTime, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if(tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpPosLocal(transform, target, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpPosLocal(Transform transform, Vector3 target, float tweenTime, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            Vector3 startPos = transform.localPosition;
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                transform.localPosition = Vector3.LerpUnclamped(startPos, target, timeWithEase);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localPosition = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }


        //TweenRot
        public static IEnumerator TweenRotEuler(Transform transform, Vector3 target, float tweenTime, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpRotEuler(transform, target, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpRotEuler(Transform transform, Vector3 target, float tweenTime, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            Vector3 startEuler = transform.eulerAngles;
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                transform.eulerAngles = Vector3.LerpUnclamped(startEuler, target, timeWithEase);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.eulerAngles = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        public static IEnumerator TweenRotEulerLocal(Transform transform, Vector3 target, float tweenTime, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpRotEulerLocal(transform, target, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpRotEulerLocal(Transform transform, Vector3 target, float tweenTime, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            Vector3 startEuler = transform.localEulerAngles;
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                transform.localEulerAngles = Vector3.LerpUnclamped(startEuler, target, timeWithEase);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localEulerAngles = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }

        public static IEnumerator TweenRotQuaternion(Transform transform, Quaternion target, float tweenTime, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpRotQuaternion(transform, target, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpRotQuaternion(Transform transform, Quaternion target, float tweenTime, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            Quaternion startQuaternion = transform.rotation;
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                transform.rotation = Quaternion.LerpUnclamped(startQuaternion, target, timeWithEase);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.rotation = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        public static IEnumerator TweenRotQuaternionLocal(Transform transform, Quaternion target, float tweenTime, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpRotQuaternionLocal(transform, target, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpRotQuaternionLocal(Transform transform, Quaternion target, float tweenTime, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            Quaternion startQuaternion = transform.localRotation;
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                transform.localRotation = Quaternion.LerpUnclamped(startQuaternion, target, timeWithEase);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localRotation = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }


        //TweenVectors
        public static IEnumerator TweenVector2(Vector2 from, Vector2 to, float tweenTime, Action<Vector2> onUpdate, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpVector2(from, to, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpVector2(Vector2 from, Vector2 to, float tweenTime, Action<Vector2> onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                Vector2 lerpValue = Vector2.LerpUnclamped(from, to, timeWithEase);
                onUpdate?.Invoke(lerpValue);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            onUpdate?.Invoke(to);
            onFinish?.Invoke();
        }
        public static IEnumerator TweenVector3(Vector3 from, Vector3 to, float tweenTime, Action<Vector3> onUpdate, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpVector3(from, to, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpVector3(Vector3 from, Vector3 to, float tweenTime, Action<Vector3> onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                Vector3 lerpValue = Vector3.LerpUnclamped(from, to, timeWithEase);
                onUpdate?.Invoke(lerpValue);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            onUpdate?.Invoke(to);
            onFinish?.Invoke();
        }


        //TweenColor
        public static IEnumerator TweenColor(Color from, Color to, float tweenTime, Action<Color> onUpdate, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if(tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }
            IEnumerator tween = LerpColor(from, to, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpColor(Color from, Color to, float tweenTime, Action<Color> onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            float timeElapsed = 0;

            while(timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                Color lerpValue = Color.LerpUnclamped(from, to, timeWithEase);
                onUpdate?.Invoke(lerpValue);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            onUpdate?.Invoke(to);
            onFinish?.Invoke();
        }


        //TweenCanvasGroup
        public static IEnumerator TweenCanvasGroup(CanvasGroup canvasGroup, float targetAlpha, float tweenTime, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }
            IEnumerator tween = LerpCanvasGroup(canvasGroup, targetAlpha, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpCanvasGroup(CanvasGroup canvasGroup, float targetAlpha, float tweenTime, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            float timeElapsed = 0;
            float startAplha = canvasGroup.alpha;

            while(timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                canvasGroup.alpha = Mathf.LerpUnclamped(startAplha, targetAlpha, timeWithEase);
                onUpdate?.Invoke();
                onFinish?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            canvasGroup.alpha = targetAlpha;
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




        //Easing
        private const float _elasticConst1 = (2 * Mathf.PI) / 3;
        private const float _elasticConst2 = (2 * Mathf.PI) / 4.5f;

        private const float _backConst1 = 1.70158f;
        private const float _backConst2 = _backConst1 * 1.525f;
        private const float _backConst3 = _backConst1 + 1;

        private const float _bounceNumeratorConst = 7.5625f;
        private const float _bounceDenominatorConst = 2.75f;

        //Linear
        public static float Linear(float time) => time;
        //Sine
        public static float EaseInSine(float time) => (float)1-Mathf.Cos((time * Mathf.PI) / 2);
        public static float EaseOutSine(float time) => (float)Mathf.Sin((time * Mathf.PI) / 2);
        public static float EaseInOutSine(float time) => (float)-(Mathf.Cos(Mathf.PI * time) - 1) / 2;
        //Cubic
        public static float EaseInCubic(float time) => time * time * time;
        public static float EaseOutCubic(float time) => 1 - Mathf.Pow(1 - time, 3);
        public static float EaseInOutCubic(float time) => time < 0.5f ? 4 * time * time * time : 1 - Mathf.Pow(-2 * time + 2, 3) / 2;
        //Quint
        public static float EaseInQuint(float time) => time * time * time * time * time;
        public static float EaseOutQuint(float time) => 1 - Mathf.Pow(1 - time, 5);
        public static float EaseInOutQuint(float time) => time < 0.5f ? 16 * time * time * time * time * time : 1 - Mathf.Pow(-2 * time + 2, 5) / 2;
        //Circ
        public static float EaseInCirc(float time) => 1 - Mathf.Sqrt(1 - Mathf.Pow(time, 2));
        public static float EaseOutCirc(float time) => Mathf.Sqrt(1 - Mathf.Pow(time - 1, 2));
        public static float EaseInOutCirc(float time) => time < 0.5f ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * time, 2))) / 2 : (Mathf.Sqrt(1 - Mathf.Pow(-2 * time + 2, 2)) + 1) / 2;
        //Elastic
        public static float EaseInElastic(float time) => time == 0 ? 0 : time == 1 ? 1 : -Mathf.Pow(2, 10 * time - 10) * Mathf.Sin((time * 10 - 10.75f) * _elasticConst1);
        public static float EaseOutElastic(float time) => time == 0 ? 0 : time == 1 ? 1 : Mathf.Pow(2, -10 * time) * Mathf.Sin((time* 10 - 0.75f) * _elasticConst1) + 1;
        public static float EaseInOutElastic(float time)
        {
            return time == 0 ? 0 : time == 1 ? 1 : time < 0.5f ?
                -(Mathf.Pow(2, 20 * time - 10) * Mathf.Sin((20 * time - 11.125f) * _elasticConst2)) / 2 :
                (Mathf.Pow(2, -20 * time + 10) * Mathf.Sin((20 * time - 11.125f) * _elasticConst2)) / 2 + 1;
        }
        //Quad
        public static float EaseInQuad(float time) => time * time;
        public static float EaseOutQuad(float time) => 1 - (1 - time) * (1 - time);
        public static float EaseInOutQuad(float time) => time < 0.5f ? 2 * time * time : 1 - Mathf.Pow(-2 * time + 2, 2) / 2;
        //Quart
        public static float EaseInQuart(float time) => time * time * time * time;
        public static float EaseOutQuart(float time) => 1 - Mathf.Pow(1 - time, 4);
        public static float EaseInOutQuart(float time) => time < 0.5f ? 8 * time * time * time * time : 1 - Mathf.Pow(-2 * time + 2, 4) / 2;
        //Expo
        public static float EaseInExpo(float time) => time == 0 ? 0 : Mathf.Pow(2, 10 * time - 10);
        public static float EaseOutExpo(float time) => time == 1 ? 1 : 1 - Mathf.Pow(2, -10 * time);
        public static float EaseInOutExpo(float time) => time == 0 ? 0 : time == 1 ? 1 : time < 0.5f ? Mathf.Pow(2, 20 * time - 10) / 2 : (2 - Mathf.Pow(2, -20 * time + 10)) / 2;
        //Back
        public static float EaseInBack(float time) => _backConst3 * time * time * time - _backConst1 * time * time;
        public static float EaseOutBack(float time) => 1 + _backConst3 * Mathf.Pow(time - 1, 3) + _backConst1 * Mathf.Pow(time - 1, 2);
        public static float EaseInOutBack(float time)
        {
            return time < 0.5f ? 
                (Mathf.Pow(2 * time, 2) * ((_backConst2 + 1) * 2 * time - _backConst2)) / 2 : 
                (Mathf.Pow(2 * time - 2, 2) * ((_backConst2 + 1) * (time * 2 - 2) + _backConst2) + 2) / 2;
        }
        //Bounce
        public static float EaseInBounce(float time) => 1 - EaseOutBounce(1 - time);
        public static float EaseOutBounce(float time)
        {
            if (time < 1 / _bounceDenominatorConst) return _bounceNumeratorConst * time * time;
            else if (time < 2 / _bounceDenominatorConst) return _bounceNumeratorConst * (time -= 1.5f / _bounceDenominatorConst) * time + 0.75f;
            else if (time < 2.5f / _bounceDenominatorConst) return _bounceNumeratorConst * (time -= 2.25f / _bounceDenominatorConst) * time + 0.9375f;
            else return _bounceNumeratorConst * (time -= 2.625f / _bounceDenominatorConst) * time + 0.984375f;
        }
        public static float EaseInOutBounce(float time) => time < 0.5f ? (1 - EaseOutBounce(1 - 2 * time)) / 2 : (1 + EaseOutBounce(2 * time - 1)) / 2;


        private static Func<float, float>[] _easeMethods =
        {
            Linear,
            EaseInSine,     EaseOutSine,    EaseInOutSine,
            EaseInCubic,    EaseOutCubic,   EaseInOutCubic,
            EaseInQuint,    EaseOutQuint,   EaseInOutQuint,
            EaseInCirc,     EaseOutCirc,    EaseInOutCirc,
            EaseInElastic,  EaseOutElastic, EaseInOutElastic,
            EaseInQuad,     EaseOutQuad,    EaseInOutQuad,
            EaseInQuart,    EaseOutQuart,   EaseInOutQuart,
            EaseInExpo,     EaseOutExpo,    EaseInOutExpo,
            EaseInBack,     EaseOutBack,    EaseInOutBack,
            EaseInBounce,   EaseOutBounce,  EaseInOutBounce,
        };
    }

    public enum TweenEase
    {
        Linear,
        EaseInSine,     EaseOutSine,    EaseInOutSine,
        EaseInCubic,    EaseOutCubic,   EaseInOutCubic,
        EaseInQuint,    EaseOutQuint,   EaseInOutQuint,
        EaseInCirc,     EaseOutCirc,    EaseInOutCirc,
        EaseInElastic,  EaseOutElastic, EaseInOutElastic,
        EaseInQuad,     EaseOutQuad,    EaseInOutQuad,
        EaseInQuart,    EaseOutQuart,   EaseInOutQuart,
        EaseInExpo,     EaseOutExpo,    EaseInOutExpo,
        EaseInBack,     EaseOutBack,    EaseInOutBack,
        EaseInBounce,   EaseOutBounce,  EaseInOutBounce,
    }
}