<h1 align="center">KosciachTween</h1>
<p align="center">
  A utility class for creating simple and useful tweens.
</p>

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
  - If key is empty or the tween does not exist, warning will be logged.<br>
  **Example:**
  ```csharp
  //Stop the the tween on Awake
  private void Awake()
  {
    Guid tweenKey = KosciachTween.Position(transform, Vector3.one, 1).Run();
    KosciachTween.RemoveTween(tweenKey);
  }
  ```

</p>

<br>
<h3 align="center">AvailableTweens</h3>
<p align="center">

  - `Position`: tweens Position.
  - `RotationEuler`: tweens rotation using EulerAngles.
  - `RotationQuaternion`: tweens rotation using Quaternion.
  - `Scale`: tweens Scale.
  - `Vector2D`: tweens Vector2 (requires use of onUpdate setting).
  - `Vector3D`: tweens Vector3 (requires use of onUpdate setting).
  - `Float`: tweens Float (requires use of onUpdate setting).
  - `Color`: tweens Color (requires use of onUpdate setting).
  - `CanvasGroupAlpha`: tweens CanvasGroup alpha, without the need of <a href="CanvasGroupController.md">CanvasGroupAlpha</a>.
</p>

<br>
<h3 align="center">AdditionalSettings/Extentions</h3>
<p align="center">

  `AdditionalSettings or Extentions` are special parts of `Tween` class that are called during tweening.
  All can be set by chaining methods to `AvailableTweens`.

  - `SetDelay`: makes tween start after specified delay in seconds.
  - `SetLocal`: used in `Position` and `Rotation`, tells those tweens to tween transform locally.
  
</p>

<p align="center">
  <a href="README.md">ReadMe</a>
</p>
