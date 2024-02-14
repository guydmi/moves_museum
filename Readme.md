*The Museum of Moves*

The Museum of Moves is a VR experience based on the theme of movement. The basic concept was to present movement in a different vizualisation, more artistic and innovative. 
It has been developped on Unity with Mixamo charaters and animations, but it could feature different kinds of skeleton and animations (we hope).

**Structure**

The museum is composed of 3 scenes : 
- a starting scene explaining a bit the context
- an exposition scene staring the sculptures of movement
- an exhibition scene to watch a movement

***The exposition scene***
In the exposition scene you can walk around 9 sculptures of movements in a sci-fi environment created by CreepyCat. The sculptures have a control pannel on which you can generate a sculpture from a given time of the animation, and a virtual physical-like button that you can press with your trigger controller to go into the exhibition scene. 

***The exhibition scene***
In the exhibition scene, you can watch the movement you have chosen in the exposition scene. You can slide through the animations frames, play and pause it. Maybe more features to come here !

***The starting scene***
Gives some information about the experience. Maybe more lore to come here as well!

**Add an animation scultpure**

The prefab Stand comes with some cool features, including a sculpture of the animation. 
To create one :
- Drag and drop your animation in the Resources folder
- Drag and drop a stand object in your scene
- Inside the stand object in the scene :
	- Stand/Statue/SculptureObject : give the animationPath, drag and drop the skeleton in the skeleton prefab and give a unique sculpture id. In the Material 1 field you can choose whatever material you want for your sculpture to be. 
	- Stand/panneau/Plane/Menu_sculpture : if not already there, drag and drop the sculptureObjet previously modified in the sculpture on time field
    - Stand/Button/PushButton : give the animation path and skeleton path as well as the animation name.

This part should be improved to only give the path of the animation and skeleton to the stand object. 

Enjoy!
