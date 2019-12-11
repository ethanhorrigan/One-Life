# One Life

2D Top Down Puzzle Platformer

## Goal
The main goal is to solve puzzles by giving life to other robots to activate charge points while defending against enemies
to complete levels.

## Gameplay

You need to have a life to be able to move. The ‘life’ must be passed by from one character (blank robot) to another. Only robot having ‘life’ can move around and shoot laser to the enemy – infected robots.  If infected robot touches robot with the life, then that robot has infected, and life is killed and the game is lost. Infected robots move faster than blank robots so they can catch them if life is kept too long in the same robot. As well infected robots can since ‘life’ and start moving towards it, but only from a distance.

## Built With

* [Unity](https://unity.com/) - Game Engine used
* [C#](https://maven.apache.org/) - Scripting

## Authors

* **Ethan Horrigan** - *Developer* - [Ethan](https://github.com/ethanhorrigan)

### Task List

- [x] Low Wall [Can NOT walk over, but can pass life through]
- [x] High Wall [Can NOT walk over & can NOT pass life over]
- [x] Enemy
- [x] Blank Robot
- [x] Active Robot

### Optional
- [x] 'life' can bounce from the wall
- [x] 'life' can bounce only a particular amount of times, say 3 times.
- [x] Add momentum to an enemy so what even if 'life' is passed away enemy still move towards the blank robot for a bit so it has a chance to touch it.
- [x] Add option to pic key in the order to pass level
- [x] Add ‘patrol’ functionality to an efected robots

## Acknowledgments

-	Buddy System-  https://prodigalson.itch.io/buddy-system
-	Serious Sam - https://serioussam.fandom.com/wiki/Serious_Sam:_The_First_Encounter

