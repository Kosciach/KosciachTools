using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KosciachTools.Canvas
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupController : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        private IEnumerator _alphaTweenCoroutine;



        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }


        public void ToggleInteractable(bool isInteractable)
        {
            if (_canvasGroup == null) _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.interactable = isInteractable;
        }
        public void ToggleBlocksRaycasts(bool blocksRaycasts)
        {
            if (_canvasGroup == null) _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.blocksRaycasts = blocksRaycasts;
        }

        public void SetAlpha(float alpha, float time = 0)
        {
            if (_canvasGroup == null) _canvasGroup = GetComponent<CanvasGroup>();

            float alphaTarget = Mathf.Clamp01(alpha);
            float tweenTime = Mathf.Clamp(time, 0, time);

            if (Mathf.Approximately(_canvasGroup.alpha, alpha))
            {
                _canvasGroup.alpha = alpha;
                return;
            }

            if(_alphaTweenCoroutine != null) StopCoroutine(_alphaTweenCoroutine);

            _alphaTweenCoroutine = TweenAlpha(alphaTarget, tweenTime);
            StartCoroutine(_alphaTweenCoroutine);
        }
        private IEnumerator TweenAlpha(float alphaTarget, float tweenTime)
        {
            float timeElapsed = 0;
            float startAlpha = _canvasGroup.alpha;

            while (timeElapsed < tweenTime)
            {
                float time = timeElapsed / tweenTime;

                _canvasGroup.alpha = Mathf.LerpUnclamped(startAlpha, alphaTarget, time);

                timeElapsed += Time.deltaTime;

                yield return null;
            }

            _canvasGroup.alpha = alphaTarget;
            _alphaTweenCoroutine = null;
        }
        public void StopAlphaTween()
        {
            if (_alphaTweenCoroutine == null)
            {
                Debug.Log("CanvasGroupController - there is no tween!");
                return;
            }

            StopCoroutine(_alphaTweenCoroutine);
            _alphaTweenCoroutine = null;
        }
    }
}