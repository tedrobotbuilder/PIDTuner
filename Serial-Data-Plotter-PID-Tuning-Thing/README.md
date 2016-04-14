# Serial-Data-Plotter-PID-Tuning-Thing
I started using this data plotter from zitron with my Arduino projects:
http://forum.arduino.cc/index.php?topic=80462.0

I found it most useful for tuning PID algorithms.  However, it had no way to send data back to the Arduino to tune parameters.  This shortcoming meant that I had to stop and change the Arduino's code and upload it each time I made a step change.  So I decided to change zitron’s app so I could change PID parameters on the fly.

The code is C# Windows form application that can communicate with anything over a COM port with serial.  The example uses an Arduino on the other end of the COM port. 
