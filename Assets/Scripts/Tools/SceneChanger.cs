using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KosciachTools.SceneChanger
{
    public class SceneChanger : MonoBehaviour
    {
        [Header("====Settings====")]
        [SerializeField] SceneEnterAnimationType _sceneEnterAnimation;


        private Action<string> _sceneEnterAnimations;
        private Action<string> _sceneExitAnimations;



        public void Awake() => SceneEnter();


        public void SceneEnter()
        {

        }
        public void ChangeScene(string sceneName)
        {

        }




        #region Animations
        private void FadeIn(string sceneName)
        {

        }
        #endregion
    }

    public enum SceneEnterAnimationType
    {
        FadeIn, ScaleIn, LeftToCenter, TopToCenter, RightToCenter, BottomToCenter
    }
    public enum SceneExitAnimationType
    {
        FadeOut, ScaleOut, CenterToLeft, CenterToTop, CenterToRight, CenterToBottom
    }
}