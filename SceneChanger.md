<h1 align="center">SceneChanger</h1>
<p align="center">
  Component that allows to change scenes with transitions.
</p>

<br>
<h3 align="center">Setup</h3>
<p align="center">
  
  To make `SceneChanger` work correctly all steps must be followed:
  - Create canvas with an image.
  - Stretch this image to cover the whole screen.
  - Change image color if needed.
  - Add SceneChanger component.
  - Set SceneChanger enter animation.

  Or add provided prefab as child of the canvas.
</p>

##

<br>
<h3 align="center">Usage</h3>
<p align="center">
  
  The `SceneChanger` MonoBehaviour class `plays` animation when new scene loads and `loads` new scene after exit animation finished playing.
This creates `smooth` transition between scenes.

  #### SceneEntering
  - `SceneChanger` provides 6 enter animations, option to not use animation or choose randomly. To change the animation simply change the field in the inspector.

  #### SceneChanging
  - `ChangeScene(string sceneName,SceneExitAnimationType sceneExitAnimation)`: plays selected animation which changes scene when it ends.
`SceneChanger` contains 6 exit animations and option to choose randomly.<br>
  **Example:**
    ```csharp
    //SceneChanger reference
    [SerializeField] SceneChanger _sceneChanger;
    
    //Change scene to MainMenuScene with ScaleOut animation on Awake
    private void Awake()
    {
      _sceneChanger.ChangeScene("MainMenuScene", SceneExitAnimationType.ScaleOut);
    }
    ```
</p>

##

<br>
<h3 align="center">Animations</h3>
<p align="center">

  #### EnterAnimations
  - `None`: enters scene without animation.
  - `Random`: enters scene with random animation.
  - `FadeIn`: enters scene with image disappearing.
  - `ScaleIn`: enters scene with images size decreasing.
  - `CenterToLeft`: enters scene with image going from center to left.
  - `CenterToTop`: enters scene with image going from center to top.
  - `CenterToRight`: enters scene with image going from center to right.
  - `CenterToBottom`: enters scene with image going from center to bottom.

##
  #### ExitAnimations
  - `Random`: exits scene with random animation.
  - `FadeIn`: exits scene with image appearing.
  - `ScaleIn`: exits scene with images size increasing.
  - `LeftToCenter`: exits scene with image going from left to center.
  - `TopToCenter`: exits scene with image going from top to center.
  - `RightToCenter`: exits scene with image going from right to center.
  - `BottomToCenter`: exits scene with image going from bottom to center.
</p>

<br>
<p align="center">
  <a href="README.md">ReadMe</a>
</p>
