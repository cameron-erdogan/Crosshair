# Crosshair

The most interesting part of this is the Crosshair class. It defines behavior for three crosshair interactions:

- OnHover: Continuously called when the crosshair hovers over an object
- OnMouseDown: Continuously called when the crosshair hovers over an object and the mouse button remains down
- OnClick: Called once on the frame where OnMouseDown is called

OnHover and OnMouseDown/OnClick are mutually exclusive, while OnMouseDown and OnClick work in conjunction with each other, and are each useful for different purposes. You'll see what I mean when you play around with the Main scene. 

#To run:

Open Main.scene. If you're familiar with first person shooter games, the controls should be familiar to you (I use a prefab from Standard Assets for the controls, I didn't write those). Objects should change color as the crosshair hovers/clicks on them. 

#Other notes:

- You can adjust the crosshair render depth with the Crosshair.Depth public property. 
