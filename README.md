# UGM
<p>Unity Game Monitor</p>
<p>rev 0.2</p>
<p>
Unity Game Monitor is a monitor on Unity for recording user's behaviors and environment attributes.If you want to improve your game quality in develop period,you can use UGM to get information when you testing your game.
</p>
<p>
Environment:<br>
&nbsp;&nbsp;Unity 2017.01<br>
&nbsp;&nbsp;Windows 10<br>
</p>
<p>
How to use UGM:<br>
<ol>
<li>Open Unity project.</li>
<li>Import UGM package in Unity asset.</li>
<li>Drag UGM prefab in scene.</li>
<li>Open UGM_config.xml and you can use objectname or tag to setup which object you want to trace.</li>
<li>Build your game Apk and install in your mobile</li>
<li>Connect adb and excute UGM.bat on windows(Warning:you have to compile UGM_LogWriter.cpp and put the execute file in the same folder first )</li>
<li>Start your game and playing it on your mobile.</li>
<li>Finally you will get two files, one is Log file, the other is record video file</li>
</ol>
</p>
<p>Log and Video Replay<br>
<ol>
<li>input Log file in UGM.html</li>
<li>play the video and Log will replay in the same time</li>
</ol>
</p>
<p>
Log file path: Application.persistenceDataPath 
</p>
<p>
Demo video:&nbsp;<a href="https://www.youtube.com/watch?v=4n4xhkdIqZ0&t" target="_blank">Tutorial Video</a>
</p>
