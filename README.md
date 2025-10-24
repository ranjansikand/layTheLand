# Lay the Land
*A physics-based puzzle-platformer where you guide a slime by shaping the world around it.*

---

## Overview

**Lay the Land** is a twist on the traditional platformer formula.  
Instead of controlling the character, you control the *environment*.  

Your goal is to strategically place objects — like boosters, bounce pads, and ramps — to guide a self-moving slime safely to the goal flag.  
Each level challenges your timing, spatial reasoning, and creativity as you sculpt the path to victory.

---

## Gameplay Features

- **20 handcrafted levels** with progressively complex challenges  
- **Sandbox Mode** for open-ended experimentation with physics objects  
- A **“Reverse Platformer”** design twist — control the platforms, not the player  
- Simple mechanics layered into increasingly creative puzzles  

---

## Development

This project was created in just a few hours for the **Platformer Jam**, built around the theme **“Reverse.”**  
The game reverses the usual genre roles — giving you control over the world instead of the character.  
It’s a small, experimental project made to explore **level design** and **emergent puzzle-solving** within Unity’s physics system.

---

## Play the Game

You can play **Lay the Land** directly in your browser:  
[**Play Lay the Land**]([https://your-game-link.com](https://unbreaded.itch.io/lay-the-land))

---

## Implementation Notes

### Structure
- Most gameplay logic lives in the **Character** script.  
  - This was done for simplicity and testing efficiency.  
  - In a larger project, this logic would ideally be distributed among object scripts.  

### Scene Setup
- Each level contains a **copied prefab** rather than a persistent one across scenes.  
  - This decision was made to make rapid level testing easier during development.  

### Tooltips
- Tooltips are implemented with smooth **DOTween** animations.  
- Though unfinished, the system is functional and efficient.  
- The tooltip system could be improved with a delegate-based structure in future iterations.  

### Modular Design
- Interactive objects use modular **component scripts** that allow for features like:  
  - Draggable behavior  
  - Tooltip display  
- While most objects share similar modules, the **BoxItem** script demonstrates how these components can be combined selectively for flexibility.  

---

## Technologies

**Engine:** Unity (C#)  
**Tools & Libraries:** DOTween  
**Focus Areas:** Physics-based gameplay, level design, modular systems  
**Status:** Completed prototype  

---

## Author

**Ranjan Sikand**  
Game Designer & Developer  
[LinkedIn](https://www.linkedin.com) | [Portfolio](https://your-portfolio-link.com) | [GitHub](https://github.com/yourusername)
