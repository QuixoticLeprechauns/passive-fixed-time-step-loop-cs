# passive-fixed-time-step-loop-cs
A passive fixed time step program loop written in C# that does not block UI.

# How Does it Work?
This unique loop construction uses Tasks and async code to achieve a fixed time step, at little cost to system performance, in C#. This loop design intentionally avoids CPU intensive lag processing, and spinlocking. It asks for seperate task to wait for the duration of your target time step once each cycle of the loop, while runniung a process in a separate task followed by, manditory, minimum waiting period to account for possible lag. The loop haults it's progression during each cycle until both tasks finish running. The use of async code allows this loop to run without blocking UI. It was written with Windows Forms in mind; this is not a requirement, hoowever.

# Disadvantages
 - This loop does not calculate time deltas. This results in lower precission compared to loops that use spinlocking.
 
