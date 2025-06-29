# Lay the Land

Place objects on the path to guide the little slime to the goal!

**Lay the Land** is a twist on the platformer genre: instead of controlling the character, you control the world. The slime moves on its own, and your job is to strategically place objects like boosters, bounce pads, and more to help it reach the flag.

The game features:  
- **20 levels** with increasing challenges.  
- A **Sandbox Mode** to experiment with the physics objects.  

This project was created in a few hours for the **Platformer Jam** with the theme Reverse (therefore, I reversed the platformer genre: you control the platforms, not the character). It’s just a quick game that I made to scratch my level-design itch.

[![Play Lay the Land](https://img.itch.zone/aW1hZ2UvMzY4MTM1MC8yMjA1OTgxOC5wbmc=/original/5CxUIb.png)](https://unbreaded.itch.io/lay-the-land)

Click the image above or [play the game here](https://unbreaded.itch.io/lay-the-land)!

A few notes on implementation:
  1. Most logic is in the Character script. I did this for efficiency more than anything else. While splitting logic into the various objects would be a better choice, it would have required more setup.
  2. The Scenes contain a copied prefab, rather than having one that carries through different scenes (like the music). This was for testing, as it made it much easier for me to test the levels I was creating. Not saying I couldn't have worked around it... I just chose not to.
  3. I never got around to finishing the Tooltip, but the implementation is pretty decent. I don't know if I would have it be a delegate-based system, but it works efficiently and looks smooth courtesy of DOTween.
  4. Different objects in the game have different modules that allow them to do things like display a tooltip or be dragged. This was modular so that I could have objects that require only some of the functionalities, though I did not make use of the ability to do so outside of the BoxItem script for Sandbox objects.

Feel free to take a look through the scripts, and contact me if you have any questions. I am unlikely to update this game, but I'm still hard at work on my other projects.
