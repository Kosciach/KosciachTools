<h1 align="center">Audio</h1>
<p align="center">
  Easy to put together audio system made up of 4 scripts.
  
  - `AudioController`:  main script.
  - `AudioControllerExtender`: right hand of the AudioController.
  - `AudioSettings`: class storing audio settings.
  - `SoundsSourcesHolder`: monoBehaviour holding references to sounds audio sources.
</p>

##
<br>
<h3 align="center">Setup</h3>
<p align="center">
  
  How to setup audio system:
  - Create empty GameObject in main scene and name it AudioController.
  - Add AudioController component to AudioController GameObject.
  - Create two empty GameObjects as children of AudioController and name them Music and Sounds.
  - Add one AudioSource to Music GameObject and assign it in AudioController inspector.
  - Add AudioSources to Sounds GameObject and assign each in AudioController inspector to SoundsSources along, and set keys.
  - In each scene create empty GameObject and name them AudioControllerExtender.
  - Add AudioControllerExtender component to each AudioControllerExtender GameObject.
  - If scene has sliders for controlling audio volume assign them in AudioControllerExtender inspector.
</p>

##
<br>
<h3 align="center">Usage</h3>
<p align="center">
  
  The `AudioController` MonoBehaviour class provides two methods for playing sounds.

  #### PlaySound(string soundName)
  - Using soundName gets correct AudioSource from `SoundsSourcesHolder` and plays its sound, but only if this soundName exists.<br>
  **Example:**
  ```csharp
  //Play shootProjectile sound
  AudioController.Instance.PlaySound(shootProjectile);
  ```
## 
  #### SpawnSound(Vector3 pos, bool localPos, string soundName)
  - This method instead of just playing sound, creates a new GameObject in the given position, local or global.
  - Adds AudioSource from the `SoundsSourcesHolder` using soundName, to it and plays it.
  - If soundName does not exit, GameObject will not be created and sound won't be played.
  **Example:**
  ```csharp
  //Spawn beeb sound at center of the scene using global pos. 
  AudioController.Instance.SpawnSound(Vector3.zero, false, beeb);
  ```
##    
  To make Unity buttons `OnClick` work with `AudioController` sound playing, simply:
  - Find button you want to play sound.
  - Add new event (the +).
  - Drag `AudioControllerExtender` into events object field.
  - From dropdown select `PlaySoundOnButtonPress`.
  - Enter name of the sound you want the button to play in the text field.
  
</p>

##
<br>
<p align="center">
  <a href="README.md">ReadMe</a>
</p>
