<h1 align="center">Delay</h1>
<p align="center">
  In order to execute code after given ammount of time, one must use Coroutine.<br>
  But creating new Coroutine and starting it is not always the best thing to do, it takes time, space and can't be used everywhere.<br>
  Delay class allows to execute code after time with just one line.
</p>
<br>



<h3 align="center">Usage</h3>
<p align="center"> 
  To execute code with delay all that has to be done is KosciachDelay.Delay(delayInSeconds, delegate).<br>
  This is really handy, fast and easy to use.<br>
  And Delay method returns IEnumerator which can be stopped with MonoBehaviours StopCoroutine or KosciachDelay.CancelDelay(IEnumerator).
</p>


<br>
<p align="center">
  <a href="README.md">ReadMe</a>
</p>
