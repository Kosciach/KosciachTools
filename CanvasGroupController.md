<h1 align="center">CanvasGroupController</h1>
<p align="center">
  Component that allows to controll most important CanvasGroup aspects.
</p>

<br>
<h3 align="center">Setup</h3>
<p align="center">
  
  To make `CanvasGroupController` work correctly:
  - Find the object you want to use with CanvasGroupController.
  - Add `CanvasGroupController` component. (CanvasGroup will be added automatically).
</p>

##

<br>
<h3 align="center">Usage</h3>
<p align="center">
  
  The `CanvasGroupController` MonoBehaviour class provides methods for toggling `interactable`, `blocksRaycasts` and smoothly change `alpha`.
  
  #### Toggles
  - `Interactable`: sets CanvasGroup interactable to given value.<br>
  **Example:**
    ```csharp
    //CanvasGroupController reference
    [SerializeField] CanvasGroupController _canvasGroupController;
    
    //Disable interactable on Awake
    private void Awake()
    {
      _canvasGroupController.ToggleInteractable(false);
    }
    ```
  - `BlocksRaycasts`: sets CanvasGroup blocksRaycasts to given value.<br>
  **Example:**
    ```csharp
    //CanvasGroupController reference
    [SerializeField] CanvasGroupController _canvasGroupController;
    
    //Disable blocksRaycasts on Awake
    private void Awake()
    {
      _canvasGroupController.ToggleBlocksRaycasts(false);
    }
    ```

##
  #### Alpha
  - `SetAlpha`: changes CanvasGroup alpha value to specified `value` over given `time`. If time is not given or it is 0, alpha will be changed instantly.
Easing can be applied by also passing `AnimationCurve` to the method.<br>
  **Example:**
    ```csharp
    //CanvasGroupController reference
    [SerializeField] CanvasGroupController _canvasGroupController;
    
    //Change alpha to 1 over 3s on Awake
    private void Awake()
    {
      _canvasGroupController.SetAlpha(1, 3);
    }
    ```

  - `StopAlphaTween`: stop CanvasGroupController alpha tween. If tween is `not` happening a message will be logged.<br>
  **Example:**
    ```csharp
    //CanvasGroupController reference
    [SerializeField] CanvasGroupController _canvasGroupController;
    
    //Stop alpha tween on Awake
    private void Awake()
    {
      _canvasGroupController.StopAlphaTween;
    }
    ```
</p>

<br>
<p align="center">
  <a href="README.md">ReadMe</a>
</p>
