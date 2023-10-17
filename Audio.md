<h1 align="center">Audio</h1>
<p align="center">
  Every game needs Audio System, in each of my gamejams I used similar design but it took valueble time to create it.<br>
  With this Audio System I can easily and quickly add audio to my games.
</p>

<br>
<h2 align="center">Scripts:</h2>

<h3 align="center">AudioController</h3>
<p align="center"> 
  Main script, used to play music, sounds, manage settings and controll sliders.<br>
  Since only one AudioController is need I based it on a Singleton.<br>
  <br>
  In order to play music smoothly throughout all scenes, AudioController is not destroyed on load.<br>
  <br>
  There are 2 ways to play sound, it can just be played from soundSource or spawned at given position.<br>
  <br>
  Settings are stored in class AudioSettings and turned into Json when needed.<br>
  <br>
  To make sliders work and change volume, AudioController adds listener to them in form of a correct method that changes volume, setting, and saves settings.
</p>

<br>

<h3 align="center">AudioControllerExtender</h3>
<p align="center"> 
  AudioControllerExtender tells AudioController when new scene is loaded and at the same time passes 2 sliders.<br>
  Sometimes AudioControllerExtender passes null instead of sliders, AudioController will just ignore null in this case.<br>
  Since buttons can't use AudioController methods it their unity events, AudioControllerExtender has a method to handle that.<br>
</p>

<br>

<h3 align="center">AudioSettings</h3>
<p align="center"> 
  Just a small class that holds Music and Sounds volume. To save settings this class is turned in Json.
</p>

<br>

<h3 align="center">SoundsSourcesHolder</h3>
<p align="center"> 
  This scripts job is to act similarly to a dictionary, it has 2 list, keys and soundsSources.<br>
  By not using normal dictionary but custom class, it can be easily serialized in inspector, and can have special methods.<br>
  KeyExists - checks if key in present.<br>
  GetSound - uses given key to return soundSource(only if key exists).<br>
  SetVolume - sets all soundsSources volume to given value.
</p>
