# unity-rush00-2

Top-down action game made with Unity. The project contains a main menu and three playable levels where the player must eliminate all enemies, survive gunfights, and reach the exit to advance.

## Project purpose

This project is a small arcade shooter prototype inspired by fast-paced room-clearing games:

- move through closed arenas
- pick up and use weapons found in the level
- kill every enemy in the room
- reach the end trigger to load the next scene

The game flow defined in the build settings is:

1. MainMenu
2. Level1
3. Level2
4. Level3

## Technical information

- Engine version: Unity 2017.3.0f3
- Language: C#
- Package dependencies: none declared in UnityPackageManager/manifest.json
- Main runtime scenes: Assets/Scenes/MainMenu.unity, Assets/Scenes/Level1.unity, Assets/Scenes/Level2.unity, Assets/Scenes/Level3.unity

## How to open the project

1. Start Unity Hub.
2. Add the project folder.
3. Open the folder root of this repository.
4. Use Unity 2017.3.0f3 when possible to avoid compatibility issues.

If Unity Hub is not available, open the project directly from the Unity editor by selecting the repository root.

## How to run in the editor

1. Open Assets/Scenes/MainMenu.unity.
2. Press Play in the Unity editor.
3. Use the menu buttons to start the game.

You can also open Assets/Scenes/Level1.unity directly if you want to skip the menu while testing gameplay.

## How to build

1. Open File > Build Settings.
2. Check that the scenes are listed in this order:
   - Assets/Scenes/MainMenu.unity
   - Assets/Scenes/Level1.unity
   - Assets/Scenes/Level2.unity
   - Assets/Scenes/Level3.unity
3. Select a target platform.
4. Click Build or Build And Run.
5. Choose an output folder.

On macOS, Unity will usually generate an .app bundle for a standalone build.

## How to run the built game

- macOS: open the generated application bundle.
- Windows: run the generated .exe.
- Linux: run the generated executable file.

The game starts on the main menu if the build scene order matches the current project settings.

## Controls

- Move: W, A, S, D or arrow keys
- Aim: mouse cursor
- Shoot: left click when holding a weapon
- Pick up a weapon: E or left click when standing on a weapon and currently unarmed
- Throw current weapon: right click
- Pause: Escape
- Restart current level: Backspace
- Debug god mode toggle: G

## Gameplay rules

- The player rotates toward the mouse cursor.
- Weapons have limited ammo unless marked as infinite ammo.
- Fired weapons alert nearby enemies through a sound propagation radius.
- Enemies patrol, react to gunshots, chase the player on sight, and fire when they have line of sight.
- A level is completed only when every enemy is dead and the player reaches the exit trigger.
- If the player dies, a lose screen is displayed and time is paused.

## Example play session

1. Launch MainMenu.
2. Start the first level.
3. Move with WASD toward a weapon.
4. Press E to pick it up.
5. Aim with the mouse and left click to shoot enemies.
6. Clear the room.
7. Walk to the level exit to load the next scene.

## Useful project structure

- Assets/Scenes: game scenes and level flow
- Assets/Scripts: gameplay scripts
- Assets/prefab: reusable game objects and level entities
- Assets/Sprites: visual assets
- Assets/Audio: music and sound effects
- ProjectSettings: Unity editor and build configuration

## Main scripts

- Assets/Scripts/player.cs: player movement, aiming, weapon pickup, shooting, throwing, death state
- Assets/Scripts/Weapon.cs: weapon fire rate, ammo handling, projectile spawning, thrown weapon physics
- Assets/Scripts/enemi.cs: enemy patrol, sound detection, line-of-sight pursuit, attack logic
- Assets/Scripts/EndOfLevel.cs: pause menu, lose screen, win screen, scene transitions
- Assets/Scripts/BoutonActionScene.cs: main menu and UI button actions
- Assets/Scripts/checkPoint.cs: enemy patrol path switching inside trigger zones
- Assets/Scripts/MusicManager.cs: random music selection at scene start

## Notes

- The project relies on an older Unity version. Opening it in a newer editor may trigger automatic asset or API upgrades.
- Scene progression depends on the build index order stored in ProjectSettings/EditorBuildSettings.asset.
- The class names player and enemi intentionally match the current codebase naming.

## Troubleshooting

If the game does not start correctly:

- verify that all scenes are included in Build Settings
- verify that the first build scene is MainMenu
- verify that the project is opened with a Unity version compatible with 2017.3.0f3
- reimport assets from the Unity editor if sprites, audio, or prefabs are missing

If inputs seem unresponsive:

- make sure the Game view has focus in the editor
- check that Time.timeScale is not left at 0 after pausing

## Repository status

This repository contains the full Unity project and can be opened directly by the editor without any external package installation.