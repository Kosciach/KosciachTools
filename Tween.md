<h1 align="center">KosciachTween</h1>
<p align="center">
  A utility class for creating simple and useful tweens.
</p>

##
<br>
<h3 align="center">Usage</h3>
<p align="center">

  #### Creating&RunningTween
  - Call one of available tween methods, for example `Position(Transform transform, Vector3 to, float tweenTime)`.
  - Pass all the required parameters.
  - Add additional settings, like `.SetDelay(float delay)`.
  - Finally start the tween with `.Run()`.<br>

  **Example:**
  ```csharp
  //Tween global position on x axis to 5 in 3s with 2s delay on Awake.
  private void Awake()
  {
    KosciachTween.Position(transform, Vector3.one * 5, 3).SetAxis(TweenAxis.X).SetDelay(2).Run();
  }
  ```

##
  #### StoppingTween
  - Tweens are stored in a dictionary and each tween has its own unique key.
  - `RemoveTween(Guid tweenKey)` stops the tween and removes it from the dictionary (tweens are also removed from dictionary after they end).
  - To stop the tween save key returned by `.Run()` and pass it to `RemoveTween(Guid tweenKey)`.
  - If key is empty or the tween does not exist, warning will be logged.
  - Ammount of tweens running can be checked with `GetTweensCount()`.<br>
  **Example:**
  ```csharp
  //Stop the the tween on Awake
  private void Awake()
  {
    Guid tweenKey = KosciachTween.Position(transform, Vector3.one, 1).Run();
    KosciachTween.RemoveTween(tweenKey);
  }
  ```

##
  #### AvailableTweens
  - `Position`: tweens Position.
  - `RotationEuler`: tweens rotation using EulerAngles.
  - `RotationQuaternion`: tweens rotation using Quaternion.
  - `Scale`: tweens Scale.
  - `Vector2D`: tweens Vector2 (requires use of onUpdate setting).
  - `Vector3D`: tweens Vector3 (requires use of onUpdate setting).
  - `Float`: tweens Float (requires use of onUpdate setting).
  - `Color`: tweens Color (requires use of onUpdate setting).
  - `CanvasGroupAlpha`: tweens CanvasGroup alpha, without the need of <a href="CanvasGroupController.md">CanvasGroupAlpha</a>.

##
  #### AdditionalSettings/Extentions
  `AdditionalSettings or Extentions` are special parts of `Tween` class that are called during tweening.
  All can be set by chaining methods to `AvailableTweens`.

  - `SetDelay(float delay)`: makes tween start after specified delay in seconds.
  - `SetLocal()`: used by Position and Rotation, tells those tweens to tween transform locally.
  - `SetAxis(TweenAxis axis)`: specifies which axis should be affected by tween.
  - `SetEase(TweenEase ease)`: applies easing to tween.
  - `SetOnFinish(Action onFinish)`: sets delegate that is invoked at then end of tween.
  - `SetOnUpdate(Action onUpdate)`: sets delegate that is called on each tween loop iteration.
  - `SetOnUpdate(Action<Vector2> onUpdate)`: sets delegate that is called on each tween loop iteration and passes Vector2.
  - `SetOnUpdate(Action<Vector3> onUpdate)`: sets delegate that is called on each tween loop iteration and passes Vector3.
  - `SetOnUpdate(Action<Color> onUpdate)`: sets delegate that is called on each tween loop iteration and passes Color.
  - `SetOnUpdate(Action<float> onUpdate)`: sets delegate that is called on each tween loop iteration and passes float.
    
  **Example:**
  ```csharp
  //Tell Position tween to use local pos.
  KosciachTween.Position(transform, Vector3.zero, 1).SetLocal().Run();
  ```

##
  #### Easing
  `Easing` is optional and can be added using by chaining `.SetEase(TweenEase ease)`.<br>
  There are 31 easing methods.

  - `Linear`: Default.
  - `EaseInSine`, `EaseOutSine`, `EaseInOutSine`.
  - `EaseInCubic`, `EaseOutCubic`, `EaseInOutCubic`.
  - `EaseInQuint`, `EaseOutQuint`, `EaseInOutQuint`.
  - `EaseInCirc`, `EaseOutCirc`, `EaseInOutCirc`.
  - `EaseInElastic`, `EaseOutElastic`, `EaseInOutElastic`.
  - `EaseInQuad`, `EaseOutQuad`, `EaseInOutQuad`.
  - `EaseInQuart`, `EaseOutQuart`, `EaseInOutQuart`.
  - `EaseInExpo`, `EaseOutExpo`, `EaseInOutExpo`.
  - `EaseInBack`, `EaseOutBack`, `EaseInOutBack`.
  - `EaseInBounce`, `EaseOutBounce`, `EaseInOutBounce`.

  **Example:**
  ```csharp
  //Add EaseInOutSine to tween.
  KosciachTween.Position(transform, Vector3.zero, 1).SetEase(EaseInOutSine).Run();
  ```
  
</p>

##
<br>
<p align="center">
  <a href="README.md">ReadMe</a>
</p>
