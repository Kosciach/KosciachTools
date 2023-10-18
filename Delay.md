<h1 align="center">KosciachDelay</h1>
<p align="center">
  A utility class for easily adding and cancelling delays in Unity.
</p>

<br>
<h3 align="center">Usage</h3>
<p align="center">
  The `KosciachDelay` class provides methods for adding delays and cancelling them in Unity. This can be useful for scheduling actions to occur after a specified time.

  #### Adding a Delay
  - `Delay(float delayTime, Action callback)`: Add a delay and specify a callback to be executed after the delay time. If `delayTime` is negative or `callback` is null, a warning will be logged, and the delay won't be created.

  **Example:**
  ```csharp
  // Delay for 2 seconds and then perform the specified action
  KosciachDelay.Delay(2f, () => {
      Debug.Log("Delayed action executed!");
  });
  ```

  #### Cancelling a Delay
  - `CancelDelay(IEnumerator delay)`: Cancel a previously created delay by passing the IEnumerator returned by the Delay method. If the provided `delay` is null, a warning will be logged.

  **Example:**
  ```csharp
  // Create a delay and save the IEnumerator
  IEnumerator myDelay = KosciachDelay.Delay(3f, () => {
    Debug.Log("This action should be cancelled.");
  });

  // Cancel the previously created delay
  KosciachDelay.CancelDelay(myDelay);
  ```
</p>

<br>
<p align="center">
  <a href="README.md">ReadMe</a>
</p>
