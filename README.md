# Dungeon Explorer

A terminal-based dungeon crawler written in C#. You are trapped in a dungeon with the entrance gate closed behind you. Find the lever, raise the gate, and escape alive with or without the treasure, while avoiding enemies and pits.

## Features

- Five difficulty levels.
- Hidden enemies and pits that warn you when you're next to them (in all 8-sides)
- Arrows that can hit enemies from anywhere along a row or column
- Colorful console output and tables using the [Spectre.Console](https://spectreconsole.net/)
- Commands typed in plain text, each with a short alias

## Requirements

-.NET 10 SDK
- C# 14
- The Spectre.Console

## Getting Started

1. Clone or download the project.
    ```bash
    git clone 
    ```
2. Install the dependency if it isn't already referenced:

   ```bash
   dotnet add package Spectre.Console
   ```
3. Build this project
    ```bash
    dotnet build
    ```
4. Run the game from the project folder:

   ```bash
   dotnet run
   ```

## How to Play

You start at the entrance, which is also the exit. The map is not shown with its contents: you only see your own position, so you have to explore carefully.

### Objectives

1. **Find the lever** and pull it to raise the entrance gate.
2. **Find the treasure** and take it (optional).
3. **Return to the entrance** with the gate open to escape.

Taking the treasure is not required to win. It only changes the ending message.

### Commands

| Category |                                     Commands                                                                     |
|----------|------------------------------------------------------------------------------------------------------------------|
| Movement |          `go up` / `up`, `go down` / `down`, `go left` / `left`, `go right` / `right`                            |
| Actions  |                  `move lever` / `lever`, `take treasure` / `treasure`                                            |
|  Attack  | `shoot up` / `arrow up`, `shoot down` / `arrow down`, `shoot left` / `arrow left`, `shoot right` / `arrow right` |
|  Other   |                  `help` shows the commands table, `quit game` / `quit` ends the game                             |

Commands are not case-sensitive. Walking into the edge of the map just tells you there is a wall.

### Dangers

| Enemies & Traps |                                                                              |
|-----------------|------------------------------------------------------------------------------|
|  Wind Elemental | Deals 1 damage, blows you one tile up and two tiles right, then is destroyed |
|  Fire Elemental | Deals 3 damage, then is destroyed                                            |
|     Dragon      | Deals 6 damage which cause instant death                                     |
|      Pit        | Instant defeat                                                               |

You start with **6 lives** and **3 arrows**. When an enemy or pit is in one of the eight tiles around you, the game warns you, so use those hints to decide where to step or shoot.

### Difficulties

| Difficulty | Map size |
|------------|----------|
|   Easy     |   4x4    |
|  Normal    |   6x6    |
|   Hard     |   8x8    |
|  Extreme   |  10x10   |
|  Ultimate  |  12x12   |

Higher difficulties have more enemies and pits.

## License
This project is licensed under the MIT License.

## Credits
This project was made by Panagiotis Giannou.