This is a demo created by me in Unity3D showcasing my knowledge about unity3D and scripting in C#. It is not a complete game. All the 3D assets used in this demo are available for free on the unity asset store
Credit of all the assets goes to their respective creators.

Features:
The player can use WASD keys to roam around the game world.
The player can pickup a weapon using E key.
The player can shoot using Left Mouse button.
The player can reload using R key.
The player cannot shoot when the ammo count is 0.
The player will die when health count reaches 0.
The player can shoot enemies.
The enemies will track the player and if the player comes in the field of vision of the enemies they will shoot him.
The shooting state of enemyAI has a run animation due to lack of shooting animations available on the asset store.
Shooting and reloading sound and muzzle flash is also implemented.

Scripts and their use:
EnemyBehaviour.cs - EnemyAI script responsible for tracking and shooting the player.
LookX.cs and LookY.cs - Used to control the movement of mouse in the X and Y direction.
Player.cs - Player script responsible for how the player behaves.
UIManager.cs - Used to manage all the UI elements on screen like updating the health count and ammo count etc.
Weapon.cs - Weapon behaviour script.

The player can fall off the game world if he goes beyond the main road. This can be fixed easily using code and will be done in the future.
The Build_v1 folder has a compiled version of the game which can run even without unity installed on the system.
 