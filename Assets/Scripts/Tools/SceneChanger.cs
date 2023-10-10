using KosciachTools.Delay;
using KosciachTools.Tween;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace KosciachTools.SceneChanger
{
    [RequireComponent(typeof (CanvasGroupController))]
    public class SceneChanger : MonoBehaviour
    {
        [Header("====Settings====")]
        [SerializeField] SceneEnterAnimationType _sceneEnterAnimation;


        private CanvasGroupController _canvasGroupController;
        private CanvasScaler _canvasScaler;

        private Action[] _sceneEnterAnimations;
        private Action<string>[] _sceneExitAnimations;

        private Vector3 _leftPos => new Vector3((_canvasScaler.referenceResolution.x + 10), 0, 0);
        private Vector3 _topPos => new Vector3(0, (_canvasScaler.referenceResolution.y + 180), 0);
        private Vector3 _rightPos => new Vector3(-(_canvasScaler.referenceResolution.x + 10), 0, 0);
        private Vector3 _bottomPos => new Vector3(0, -(_canvasScaler.referenceResolution.y + 180), 0);



        public void Awake()
        {
            _canvasGroupController = GetComponent<CanvasGroupController>();
            _canvasScaler = transform.root.GetComponent<CanvasScaler>();
            SetAnimations();
            SceneEnter();
        }



        private void SetAnimations()
        {
            _sceneEnterAnimations = new Action[6];
            _sceneExitAnimations = new Action<string>[6];

            _sceneEnterAnimations[0] = FadeIn;
            _sceneEnterAnimations[1] = ScaleIn;
            _sceneEnterAnimations[2] = CenterToLeft;
            _sceneEnterAnimations[3] = CenterToTop;
            _sceneEnterAnimations[4] = CenterToRight;
            _sceneEnterAnimations[5] = CenterToBottom;

            _sceneExitAnimations[0] = FadeOut;
            _sceneExitAnimations[1] = ScaleOut;
            _sceneExitAnimations[2] = LeftToCenter;
            _sceneExitAnimations[3] = TopToCenter;
            _sceneExitAnimations[4] = RightToCenter;
            _sceneExitAnimations[5] = BottomToCenter;
        }


        public void SceneEnter()
        {
            if(_sceneEnterAnimation == SceneEnterAnimationType.None)
            {
                _canvasGroupController.ToggleBlocksRaycasts(false);
                _canvasGroupController.SetAlpha(0);
                transform.localPosition = Vector3.zero;
                transform.localScale = Vector3.zero;

                return;
            }

            int enterAnimationIndex = _sceneEnterAnimation == SceneEnterAnimationType.Random ? UnityEngine.Random.Range(0, _sceneEnterAnimations.Length) - 2 : (int)_sceneEnterAnimation - 2;
            _canvasGroupController.ToggleBlocksRaycasts(true);
            _canvasGroupController.SetAlpha(1);
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;

            _sceneEnterAnimations[enterAnimationIndex]();
        }
        public void ChangeScene(string sceneName,SceneExitAnimationType sceneExitAnimation)
        {
            int exitAnimationIndex = sceneExitAnimation == SceneExitAnimationType.Random ? UnityEngine.Random.Range(0, _sceneExitAnimations.Length) - 1 : (int)sceneExitAnimation - 1;
            _sceneExitAnimations[exitAnimationIndex](sceneName);
        }




        #region Animations
        private void FadeIn()
        {
            _canvasGroupController.SetAlpha(0, 0.5f);
            KosciachDelay.Delay(0.5f, () => { _canvasGroupController.ToggleBlocksRaycasts(false); });
        }
        private void ScaleIn()
        {
            KosciachTween.Scale(transform, Vector3.zero, 1).SetEase(TweenEase.EaseInOutCubic).SetOnFinish(() =>
            {
                _canvasGroupController.ToggleBlocksRaycasts(false);
            }).Run();
        }
        private void CenterToLeft()
        {
            _canvasGroupController.SetAlpha(1);
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;

            KosciachTween.Position(transform, _leftPos, 1).SetLocal().SetAxis(TweenAxis.X).SetEase(TweenEase.EaseInOutCubic).SetOnFinish(() =>
            {
                _canvasGroupController.ToggleBlocksRaycasts(false);
            }).Run();
        }
        private void CenterToTop()
        {
            _canvasGroupController.SetAlpha(1);
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;

            KosciachTween.Position(transform, _topPos, 1).SetLocal().SetAxis(TweenAxis.Y).SetEase(TweenEase.EaseInOutCubic).SetOnFinish(() =>
            {
                _canvasGroupController.ToggleBlocksRaycasts(false);
            }).Run();
        }
        private void CenterToRight()
        {
            _canvasGroupController.SetAlpha(1);
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;

            KosciachTween.Position(transform, _rightPos, 1).SetLocal().SetAxis(TweenAxis.X).SetEase(TweenEase.EaseInOutCubic).SetOnFinish(() =>
            {
                _canvasGroupController.ToggleBlocksRaycasts(false);
            }).Run();
        }
        private void CenterToBottom()
        {
            _canvasGroupController.SetAlpha(1);
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;

            KosciachTween.Position(transform, _bottomPos, 1).SetLocal().SetAxis(TweenAxis.Y).SetEase(TweenEase.EaseInOutCubic).SetOnFinish(() =>
            {
                _canvasGroupController.ToggleBlocksRaycasts(false);
            }).Run();
        }


        private void FadeOut(string sceneName)
        {
            _canvasGroupController.ToggleBlocksRaycasts(true);
            _canvasGroupController.SetAlpha(0);
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;

            _canvasGroupController.SetAlpha(1, 0.5f);
            KosciachDelay.Delay(0.5f, () => { SceneManager.LoadScene(sceneName); });
        }
        private void ScaleOut(string sceneName)
        {
            _canvasGroupController.ToggleBlocksRaycasts(true);
            _canvasGroupController.SetAlpha(1);
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.zero;

            KosciachTween.Scale(transform, Vector3.one, 1).SetEase(TweenEase.EaseInOutCubic).SetOnFinish(() =>
            {
                SceneManager.LoadScene(sceneName);
            }).Run();
        }
        private void LeftToCenter(string sceneName)
        {
            _canvasGroupController.ToggleBlocksRaycasts(true);
            _canvasGroupController.SetAlpha(1);
            transform.localPosition = _leftPos;
            transform.localScale = Vector3.one;

            KosciachTween.Position(transform, Vector3.zero, 1).SetLocal().SetAxis(TweenAxis.X).SetEase(TweenEase.EaseInOutCubic).SetOnFinish(() =>
            {
                SceneManager.LoadScene(sceneName);
            }).Run();
        }
        private void TopToCenter(string sceneName)
        {
            _canvasGroupController.ToggleBlocksRaycasts(true);
            _canvasGroupController.SetAlpha(1);
            transform.localPosition = _topPos;
            transform.localScale = Vector3.one;

            KosciachTween.Position(transform, Vector3.zero, 1).SetLocal().SetAxis(TweenAxis.Y).SetEase(TweenEase.EaseInOutCubic).SetOnFinish(() =>
            {
                SceneManager.LoadScene(sceneName);
            }).Run();
        }
        private void RightToCenter(string sceneName)
        {
            _canvasGroupController.ToggleBlocksRaycasts(true);
            _canvasGroupController.SetAlpha(1);
            transform.localPosition = _rightPos;
            transform.localScale = Vector3.one;

            KosciachTween.Position(transform, Vector3.zero, 1).SetLocal().SetAxis(TweenAxis.X).SetEase(TweenEase.EaseInOutCubic).SetOnFinish(() =>
            {
                SceneManager.LoadScene(sceneName);
            }).Run();
        }
        private void BottomToCenter(string sceneName)
        {
            _canvasGroupController.ToggleBlocksRaycasts(true);
            _canvasGroupController.SetAlpha(1);
            transform.localPosition = _bottomPos;
            transform.localScale = Vector3.one;

            KosciachTween.Position(transform, Vector3.zero, 1).SetLocal().SetAxis(TweenAxis.Y).SetEase(TweenEase.EaseInOutCubic).SetOnFinish(() =>
            {
                SceneManager.LoadScene(sceneName);
            }).Run();
        }
        #endregion
    }


    public enum SceneEnterAnimationType
    {
        None, Random, FadeIn, ScaleIn, CenterToLeft, CenterToTop, CenterToRight, CenterToBottom
    }
    public enum SceneExitAnimationType
    {
        Random, FadeOut, ScaleOut, LeftToCenter, TopToCenter, RightToCenter, BottomToCenter
    }
}