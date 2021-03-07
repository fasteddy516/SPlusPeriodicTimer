# SPlusPeriodicTimer
This Simpl# library provides a basic implementation of a periodic (recurring) timer for use in Simpl+ modules.  It is useful in places where you might otherwise find yourself using an oscillator symbol in Simpl Windows as a trigger on a Simpl+ digital input to generate a recurring event.


### Usage
In order to use this library, you will need to do the following:

- Copy `SPlusPeriodicTimer.clz` into your project folder.

- Include the library in your Simpl+ module:  
  ```c
  #user_simplsharp_library "SPlusPeriodicTimer"
  ```

- Define a global variable to contain your timer.  Here I'm calling it `myTimer`, but you can call it whatever you like:
  ```c
  PeriodicTimer myTimer;
  ```

- Create a Simpl+ function that will be called each time the timer period expires.  I've called it `PeriodicEvent`, but once again you can call it whatever you like:
  ```c
  callback function PeriodicEvent()
  {
	  print("Timer Period Expired!\n");
  }
  ```

- Tell the compiler about the function you just created.  You should use the names of your global timer variable and simpl+ function in place of `myTimer` and `PeriodicEvent` in the example below.  The `PeriodicTimerCallback` bit in the middle has to stay as-is.  This line can go in the Simpl+ `main()` function:
  ```c
  RegisterDelegate(myTimer, PeriodicTimerCallback, PeriodicEvent);
  ```

- Initialize the timer to set the desired period (in seconds).  The example below sets up a 10-second periodic timer, and could go in the `main()` function, or anywhere else as long as it gets called before you start the timer:
  ```c
  myTimer.Initialize(10);
  ```

- At some point, you'll want to start the timer:
  ```c
  myTimer.Start();
  ```

- You will likely want to stop the timer at some point as well:
  ```c
  myTimer.Stop();
  ```

And that's all there is to it!  Once you have initialized the timer, you can start and stop it as much as you like.  Just note that any time you start the timer it goes right back to 0 - so if you stop a 10-second counter around the 5-second mark, the next time you start it will count up from 0, not continue on from 5.  

The `PeriodicTimerDemo.usp` file contains a functioning (very basic) Simpl+ example for reference.

