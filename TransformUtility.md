<h1 align="center">TransformUtility</h1>
<p align="center">
  A utility class for manipulating Unity's `Transform` components on only one axis.
</p>

<br>
<h3 align="center">Usage</h3>
<p align="center">
  
  The `KosciachTransformUtility` class provides a set of static methods to easily modify the position, rotation(Euler), and scale of a Unity `Transform` component on only one axis.<br>
  Here are some example use cases:

  #### Position
  - `SetPosX(Transform transform, float posX)`: Set the X position of the transform.
  - `SetPosY(Transform transform, float posY)`: Set the Y position of the transform.
  - `SetPosZ(Transform transform, float posZ)`: Set the Z position of the transform.
  - `SetPosXLocal(Transform transform, float posX)`: Set the local X position of the transform.
  - `SetPosYLocal(Transform transform, float posY)`: Set the local Y position of the transform.
  - `SetPosZLocal(Transform transform, float posZ)`: Set the local Z position of the transform.

  #### Scale
  - `SetScaleXLocal(Transform transform, float scaleX)`: Set the local X scale of the transform.
  - `SetScaleYLocal(Transform transform, float scaleY)`: Set the local Y scale of the transform.
  - `SetScaleZLocal(Transform transform, float scaleZ)`: Set the local Z scale of the transform.

  #### Rotation
  - `SetRotX(Transform transform, float rotX)`: Set the X rotation of the transform.
  - `SetRotY(Transform transform, float rotY)`: Set the Y rotation of the transform.
  - `SetRotZ(Transform transform, float rotZ)`: Set the Z rotation of the transform.
  - `SetRotXLocal(Transform transform, float rotX)`: Set the local X rotation of the transform.
  - `SetRotYLocal(Transform transform, float rotY)`: Set the local Y rotation of the transform.
  - `SetRotZLocal(Transform transform, float rotZ)`: Set the local Z rotation of the transform.

  **Example:**
  ```csharp
  // Set the X position of the transform to 5
  KosciachTransformUtility.SetPosX(myTransform, 5f);
  ```
</p>

<p align="center">
  <a href="README.md">ReadMe</a>
</p>
