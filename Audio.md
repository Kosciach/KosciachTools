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

  Or add provided prefab as child of the canvas.
</p>


<p align="center">
  <a href="README.md">ReadMe</a>
</p>
