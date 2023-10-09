using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KosciachTools
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupController : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        private IEnumerator _alphaTweenCoroutine;



        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            if (_canvasGroup == null)
            {
                Debug.LogError("CanvasGroupController - missing CanvasGroup");
                enabled = false;
            }
        }


        public void ToggleInteractable(bool isInteractable)
        {
            _canvasGroup.interactable = isInteractable;
        }
        public void ToggleBlocksRaycasts(bool blocksRaycasts)
        {
            _canvasGroup.blocksRaycasts = blocksRaycasts;
        }

        public void SetAlpha(float alpha, float time = 0)
        {
            float alphaTarget = Mathf.Clamp01(alpha);
            float tweenTime = Mathf.Clamp(time, 0, time);

            if (Mathf.Approximately(_canvasGroup.alpha, alpha))
            {
                _canvasGroup.alpha = alpha;
                return;
            }

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