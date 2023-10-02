using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UIElements;

namespace KosciachTools
{
    public static class KosciachTween
    {
        //TweenNumbers--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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



        //TweenPos--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static IEnumerator TweenPos(Transform transform, Vector3 target, float tweenTime, bool local, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpPos(transform, target, tweenTime, local, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        public static IEnumerator TweenPosX(Transform transform, float target, float tweenTime, bool local, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpPosX(transform, target, tweenTime, local, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        public static IEnumerator TweenPosY(Transform transform, float target, float tweenTime, bool local, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpPosY(transform, target, tweenTime, local, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        public static IEnumerator TweenPosZ(Transform transform, float target, float tweenTime, bool local, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpPosZ(transform, target, tweenTime, local, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpPos(Transform transform, Vector3 target, float tweenTime, bool local, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];

            Vector3 startPos = transform.position;
            if(local) startPos = transform.localPosition;

            float timeElapsed = 0;


            while(timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);

                if (local) transform.localPosition = Vector3.LerpUnclamped(startPos, target, timeWithEase);
                else transform.position = Vector3.LerpUnclamped(startPos, target, timeWithEase);

                onUpdate?.Invoke();

                timeElapsed += Time.deltaTime;
                yield return null;
            }


            if (local) transform.localPosition = target;
            else transform.position = target;

            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        private static IEnumerator LerpPosX(Transform transform, float target, float tweenTime, bool local, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];

            float startPosX = transform.position.x;
            if (local) startPosX = transform.localPosition.x;

            float timeElapsed = 0;


            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);

                float lerpPosX = Mathf.LerpUnclamped(startPosX, target, timeWithEase);
                if (local) transform.localPosition = new Vector3(lerpPosX, transform.localPosition.y, transform.localPosition.z);
                else transform.position = new Vector3(lerpPosX, transform.position.y, transform.position.z);

                onUpdate?.Invoke();

                timeElapsed += Time.deltaTime;
                yield return null;
            }


            if (local) transform.localPosition = new Vector3(target, transform.localPosition.y, transform.localPosition.z);
            else transform.position = new Vector3(target, transform.position.y, transform.position.z); 

            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        private static IEnumerator LerpPosY(Transform transform, float target, float tweenTime, bool local, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];

            float startPosY = transform.position.x;
            if (local) startPosY = transform.localPosition.x;

            float timeElapsed = 0;


            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);

                float lerpPosY = Mathf.LerpUnclamped(startPosY, target, timeWithEase);
                if (local) transform.localPosition = new Vector3(transform.localPosition.x, lerpPosY, transform.localPosition.z);
                else transform.position = new Vector3(transform.position.x, lerpPosY, transform.position.z);

                onUpdate?.Invoke();

                timeElapsed += Time.deltaTime;
                yield return null;
            }


            if (local) transform.localPosition = new Vector3(transform.localPosition.x, target, transform.localPosition.z);
            else transform.position = new Vector3(transform.position.x, target, transform.position.z);

            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        private static IEnumerator LerpPosZ(Transform transform, float target, float tweenTime, bool local, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];

            float startPosZ = transform.position.x;
            if (local) startPosZ = transform.localPosition.x;

            float timeElapsed = 0;


            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);

                float lerpPosZ = Mathf.LerpUnclamped(startPosZ, target, timeWithEase);
                if (local) transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, lerpPosZ);
                else transform.position = new Vector3(transform.position.x, transform.position.y, lerpPosZ);

                onUpdate?.Invoke();

                timeElapsed += Time.deltaTime;
                yield return null;
            }


            if (local) transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, target);
            else transform.position = new Vector3(transform.position.x, transform.position.y, target);

            onUpdate?.Invoke();
            onFinish?.Invoke();
        }


        //TweenRot--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static IEnumerator TweenRotEuler(Transform transform, Vector3 target, float tweenTime, bool local, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpRotEuler(transform, target, tweenTime, local, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        public static IEnumerator TweenRotEulerX(Transform transform, float target, float tweenTime, bool local, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            Vector3 targetEuler = new Vector3(target, transform.eulerAngles.y, transform.eulerAngles.z);
            IEnumerator tween = LerpRotEuler(transform, targetEuler, tweenTime, local, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        public static IEnumerator TweenRotEulerY(Transform transform, float target, float tweenTime, bool local, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            Vector3 targetEuler = new Vector3(transform.eulerAngles.x, target, transform.eulerAngles.z);
            IEnumerator tween = LerpRotEuler(transform, targetEuler, tweenTime, local, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        public static IEnumerator TweenRotEulerZ(Transform transform, float target, float tweenTime, bool local, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            Vector3 targetEuler = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, target);
            IEnumerator tween = LerpRotEuler(transform, targetEuler, tweenTime, local, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpRotEuler(Transform transform, Vector3 target, float tweenTime, bool local, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];

            Vector3 startEuler = transform.eulerAngles;
            if (local) startEuler = transform.localEulerAngles;

            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);

                if(local) transform.localEulerAngles = Vector3.LerpUnclamped(startEuler, target, timeWithEase);
                else transform.eulerAngles = Vector3.LerpUnclamped(startEuler, target, timeWithEase);

                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            if (local) transform.localEulerAngles = target;
            else transform.eulerAngles = target;

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



        //TweenScale--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static IEnumerator TweenScale(Transform transform, Vector3 target, float tweenTime, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpScale(transform, target, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        public static IEnumerator TweenScaleX(Transform transform, float target, float tweenTime, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpScaleX(transform, target, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        public static IEnumerator TweenScaleY(Transform transform, float target, float tweenTime, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpScaleY(transform, target, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        public static IEnumerator TweenScaleZ(Transform transform, float target, float tweenTime, Action onUpdate = null, Action onFinish = null, TweenEase tweenEase = TweenEase.Linear)
        {
            if (tweenTime < 0)
            {
                Debug.LogWarning("KosciachTween - tweenTime is negative!");
                return null;
            }

            IEnumerator tween = LerpScaleZ(transform, target, tweenTime, onUpdate, onFinish, tweenEase);
            KosciachTweenRunner.Instance.StartCoroutine(tween);
            return tween;
        }
        private static IEnumerator LerpScale(Transform transform, Vector3 target, float tweenTime, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            Vector3 startScale = transform.localScale;
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                transform.localScale = Vector3.LerpUnclamped(startScale, target, timeWithEase);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localScale = target;
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        private static IEnumerator LerpScaleX(Transform transform, float target, float tweenTime, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            float startScaleX = transform.localScale.x;
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                float scaleX = Mathf.LerpUnclamped(startScaleX, target, timeWithEase);
                transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localScale = new Vector3(target, transform.localScale.y, transform.localScale.z);
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        private static IEnumerator LerpScaleY(Transform transform, float target, float tweenTime, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            float startScaleY = transform.localScale.y;
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                float scaleY = Mathf.LerpUnclamped(startScaleY, target, timeWithEase);
                transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localScale = new Vector3(transform.localScale.x, target, transform.localScale.z);
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }
        private static IEnumerator LerpScaleZ(Transform transform, float target, float tweenTime, Action onUpdate, Action onFinish, TweenEase tweenEase)
        {
            Func<float, float> easeMethod = _easeMethods[(int)tweenEase];
            float startScaleZ = transform.localScale.z;
            float timeElapsed = 0;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;
                float timeWithEase = easeMethod(time);
                float scaleZ = Mathf.LerpUnclamped(startScaleZ, target, timeWithEase);
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, scaleZ);
                onUpdate?.Invoke();
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, target);
            onUpdate?.Invoke();
            onFinish?.Invoke();
        }



        //TweenVectors--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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



        //TweenColor--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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



        //TweenCanvasGroup--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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





        //TweenUtility--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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





        //Easing--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private const float _elasticConst1 = (2 * Mathf.PI) / 3;
        private const float _elasticConst2 = (2 * Mathf.PI) / 4.5f;

        private const float _backConst1 = 1.70158f;
        private const float _backConst2 = _backConst1 * 1.525f;
        private const float _backConst3 = _backConst1 + 1;

        private const float _bounceNumeratorConst = 7.5625f;
        private const float _bounceDenominatorConst = 2.75f;

        //Linear--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static float Linear(float time) => time;
        //Sine--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static float EaseInSine(float time) => (float)1-Mathf.Cos((time * Mathf.PI) / 2);
        private static float EaseOutSine(float time) => (float)Mathf.Sin((time * Mathf.PI) / 2);
        private static float EaseInOutSine(float time) => (float)-(Mathf.Cos(Mathf.PI * time) - 1) / 2;
        //Cubic--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static float EaseInCubic(float time) => time * time * time;
        private static float EaseOutCubic(float time) => 1 - Mathf.Pow(1 - time, 3);
        private static float EaseInOutCubic(float time) => time < 0.5f ? 4 * time * time * time : 1 - Mathf.Pow(-2 * time + 2, 3) / 2;
        //Quint--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static float EaseInQuint(float time) => time * time * time * time * time;
        private static float EaseOutQuint(float time) => 1 - Mathf.Pow(1 - time, 5);
        private static float EaseInOutQuint(float time) => time < 0.5f ? 16 * time * time * time * time * time : 1 - Mathf.Pow(-2 * time + 2, 5) / 2;
        //Circ--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static float EaseInCirc(float time) => 1 - Mathf.Sqrt(1 - Mathf.Pow(time, 2));
        private static float EaseOutCirc(float time) => Mathf.Sqrt(1 - Mathf.Pow(time - 1, 2));
        private static float EaseInOutCirc(float time) => time < 0.5f ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * time, 2))) / 2 : (Mathf.Sqrt(1 - Mathf.Pow(-2 * time + 2, 2)) + 1) / 2;
        //Elastic--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static float EaseInElastic(float time) => time == 0 ? 0 : time == 1 ? 1 : -Mathf.Pow(2, 10 * time - 10) * Mathf.Sin((time * 10 - 10.75f) * _elasticConst1);
        private static float EaseOutElastic(float time) => time == 0 ? 0 : time == 1 ? 1 : Mathf.Pow(2, -10 * time) * Mathf.Sin((time* 10 - 0.75f) * _elasticConst1) + 1;
        private static float EaseInOutElastic(float time)
        {
            return time == 0 ? 0 : time == 1 ? 1 : time < 0.5f ?
                -(Mathf.Pow(2, 20 * time - 10) * Mathf.Sin((20 * time - 11.125f) * _elasticConst2)) / 2 :
                (Mathf.Pow(2, -20 * time + 10) * Mathf.Sin((20 * time - 11.125f) * _elasticConst2)) / 2 + 1;
        }
        //Quad--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static float EaseInQuad(float time) => time * time;
        private static float EaseOutQuad(float time) => 1 - (1 - time) * (1 - time);
        private static float EaseInOutQuad(float time) => time < 0.5f ? 2 * time * time : 1 - Mathf.Pow(-2 * time + 2, 2) / 2;
        //Quart--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static float EaseInQuart(float time) => time * time * time * time;
        private static float EaseOutQuart(float time) => 1 - Mathf.Pow(1 - time, 4);
        private static float EaseInOutQuart(float time) => time < 0.5f ? 8 * time * time * time * time : 1 - Mathf.Pow(-2 * time + 2, 4) / 2;
        //Expo--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static float EaseInExpo(float time) => time == 0 ? 0 : Mathf.Pow(2, 10 * time - 10);
        private static float EaseOutExpo(float time) => time == 1 ? 1 : 1 - Mathf.Pow(2, -10 * time);
        private static float EaseInOutExpo(float time) => time == 0 ? 0 : time == 1 ? 1 : time < 0.5f ? Mathf.Pow(2, 20 * time - 10) / 2 : (2 - Mathf.Pow(2, -20 * time + 10)) / 2;
        //Back--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static float EaseInBack(float time) => _backConst3 * time * time * time - _backConst1 * time * time;
        private static float EaseOutBack(float time) => 1 + _backConst3 * Mathf.Pow(time - 1, 3) + _backConst1 * Mathf.Pow(time - 1, 2);
        private static float EaseInOutBack(float time)
        {
            return time < 0.5f ? 
                (Mathf.Pow(2 * time, 2) * ((_backConst2 + 1) * 2 * time - _backConst2)) / 2 : 
                (Mathf.Pow(2 * time - 2, 2) * ((_backConst2 + 1) * (time * 2 - 2) + _backConst2) + 2) / 2;
        }
        //Bounce--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static float EaseInBounce(float time) => 1 - EaseOutBounce(1 - time);
        private static float EaseOutBounce(float time)
        {
            if (time < 1 / _bounceDenominatorConst) return _bounceNumeratorConst * time * time;
            else if (time < 2 / _bounceDenominatorConst) return _bounceNumeratorConst * (time -= 1.5f / _bounceDenominatorConst) * time + 0.75f;
            else if (time < 2.5f / _bounceDenominatorConst) return _bounceNumeratorConst * (time -= 2.25f / _bounceDenominatorConst) * time + 0.9375f;
            else return _bounceNumeratorConst * (time -= 2.625f / _bounceDenominatorConst) * time + 0.984375f;
        }
        private static float EaseInOutBounce(float time) => time < 0.5f ? (1 - EaseOutBounce(1 - 2 * time)) / 2 : (1 + EaseOutBounce(2 * time - 1)) / 2;


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