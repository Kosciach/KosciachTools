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

<p align="center">
  <a href="README.md">ReadMe</a>
</p>
