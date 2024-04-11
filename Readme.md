# Knight’s Quest: The Princess Rescue

## Description
This is a text-based RPG style game created for the <i>SDEV248: Advanced Simulation and Game Design</i> course at Ivy Tech Community College.
## Packages needed
- .NET FRAMEWORK v4.8.1


# How to play
To navigate this game, the console will output a description of where the player is, what things there are to inspect, and valid exits.
The player can enter their commands in the form of \<movement> \<direction> or \<action> \<item> and the game will describe what happens.

valid movement words are: "GO", "WALK", "MOVE", "HEAD"


In this game, combat is determined by a combination of RNG and a format similar to Rock/Paper/Scissors.
During combat, both the player and the enemy choose an attack type.
  -Melee attacks beat ranged attacks.
  -Ranged attacks beat blocking.
  -Blocking beats melee attacks.
Then the player and enemy roll a number 1-10.
If you win the Rock/Paper/Scissors portion, you can add your bonus to the RNG roll.
The one that has the lowest number takes 1 damage (unless an item is equipped).

## Known issues
Currently, there are no known issues.
