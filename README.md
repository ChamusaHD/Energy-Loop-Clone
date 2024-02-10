Project Overview

The project works based on a grid where each tile equals to a 1 by 1 square. The grid detects how many node prefabs are in each rows and collums divided by the 1 by 1 square scale and takes that shape, keeping in mind that if there are blank spaces between prefabs the grid will not know how to act and give an error so we must add the null node prefab. 
  A node can have at a maximum four exits so each node has an array of values atributed for each of this four exits (Top, Right, Bottom, Left). This values can be 1 or 0 depending on if the node actually has an exit to connect with others or not. When we click the nodes to rotate, this values also get updated.
  The win condition is based on the comparison between the current conected nodes and the total conections possible, when both of these are equal it means that the player succeeded conecting all the nodes. When all the nodes are conected, the next level is loaded. 
  Unlocked levels and Score are saved with PlayerPrefs.

This was my first project experimenting with android/mobile so there are a lot of things im still not aware about mobile game development like I just found out know about Unity Remote to test moblie games directly with your mobile phone.
I was using a function to make the phone vibrate every time the player clicks to rotate a node just like the reference in Energy Loops but when tsting it was just to much so I ended up disabling it
I also had at the start of the game the nodes applying a random rotation so thw level would start diferently everytime you enter it but again in the game reference thats not what happends so i decided to cut it of aswell.

At the end I can say it was a joyfull experience and would like to keep learning.
One thing i would like to dive deeper is into particle systems and camara shakes, basically everything about player experienece and game feel.
