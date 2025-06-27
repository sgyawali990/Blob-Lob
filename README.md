# Blob Lob
This is a fast-paced local 1v1 platformer shooter built in Unity.  
Players control blobs that shoot, jump, and dodge.  
The game features falling platforms and a countdown-based match start system.

# Gameplay Overview
- Mode: Local multiplayer (1v1)  
- Objective: Deplete your opponent's lives by shooting them  
- Lives: Each player starts with 5 lives  
- Weapons: Instant-kill rifle with a 3 second reload    
- Respawn: Players respawn with a brief protection window (3 seconds)  
- Map: Platforms scroll down over time in chunks (once every 5 seconds) 

# Features
- Sound effects for gunfire, respawn, and death (funny splat)  
- Scrolling platform chunks  
- Countdown start screen with controls image (custom made :( )
- Win screen with blob image and victory message  
- Menu and options screen with music and sound toggle  
- Victory jingle and looping background music  
- Simple UI using TextMeshPro  
- Inspired by flash games (Gun Mayhem Series, Bobby's Not So Average Adventure) 

# Project Structure
- Assets/Scripts/: All game scripts (.cs files)  
  - AudioManager.cs: Manages background music and SFX  
  - GameManager.cs: Core game logic, win condition, scene control  
  - CountdownUI.cs: Handles countdown and controls screen  
  - PlayerHealth.cs: Tracks each blob's lives  
  - PlayerMovement.cs: Controls player movement  
  - PlayerShooting.cs: Handles gun logic and reload  
  - MapChunkSpawner.cs and MapShifter.cs: Platform spawning and scrolling  
  - LivesUI.cs: Shows blob head sprites and lives left  
  - MainMenuUI.cs: Handles menu navigation buttons  
- Assets/Scenes/: Contains game and menu scenes  
- Assets/SFX/: One-shot sound effects  
- Assets/Music/: Loopable background music  
- Assets/Sprites/: Blob character and platform art  
- Assets/Images/: Background and controls image  

# Setup
1. Open the project in Unity 2022.3.x LTS  
2. Open the MainMenu scene to test the full flow  
3. Verify AudioManager is present in the Menu scene  
4. Input System is already set up (actions file included)  

# Controls (Default)
Player 1  
- Move: W A S D  
- Shoot: Space  
Player 2  
- Move: Arrow Keys  
- Shoot: Enter  

# How to Build
1. Go to File > Build Settings  
2. Choose your target platform  
3. Add both MainMenu and GameScene to the Scenes In Build list  
4. Click Build  
