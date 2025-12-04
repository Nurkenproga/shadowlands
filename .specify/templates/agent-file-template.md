# [Shadowlands] Development Guidelines

Auto-generated from all feature plans. Last updated: [DATE]

## Active Technologies

Unity 2022+ (2D URP)

C# (MonoBehaviour-based architecture)

Tilemap System

ScriptableObjects (game parameters, world-switch config)

Unity Input System

Unity Timeline / Animation (optional)

Cinemachine (camera follow + smoothing)

AudioMixer for SFX switching between Real / Shadow worlds

## Project Structure

```
Assets/
  Scripts/
    Core/
      ShadowWorldManager.cs
      GameEvents.cs
      SceneController.cs
    Player/
      PlayerController.cs
      PlayerMovement.cs
      PlayerAnimation.cs
    World/
      ShadowObject.cs
      ToggleablePlatform.cs
      ToggleableHazard.cs
      EnemyAI.cs
    Systems/
      Audio/
      UI/
      SaveSystem/
  Art/
    Real/
    Shadow/
  Prefabs/
    Player/
    Platforms/
    Hazards/
    Enemies/
  Levels/
    Level_01/
    Level_02/
    Level_03/
  ScriptableObjects/
    WorldSettings.asset
    PlayerConfig.asset
    EnemyConfig.asset

```

## Commands

# Unity

Play — run the game

Ctrl + Shift + B — build settings

Ctrl + D — duplicate object

Alt + Click — expand all children

F — frame selected object

# C# / Development

dotnet format (optional, external) — apply formatting

rider . / code . — open solution in chosen IDE

## Code Style

# C# Guidelines

PascalCase for classes, methods, public fields

camelCase for private fields (with _prefix)

ONE responsibility per script

No long functions (> 25 lines)

Avoid inheritance, prefer composition

All world-switch logic must subscribe to ShadowWorldManager.OnWorldToggle

All parameters configurable through ScriptableObjects

No magic numbers — always wrap into config files

## Recent Changes

[LAST 3 FEATURES AND WHAT THEY ADDED]

1. World Switching System Added

Introduced ShadowWorldManager

Unified toggle event for all objects

Created Real/Shadow layers

2. Core Player Movement Implemented

Basic movement, jumping, coyote time

Connected to world-switch restrictions

3. Toggleable Platforms & Hazards

Platforms now activate/deactivate per world

Hazard timing synced with toggle event

Added simple polish animations

<!-- MANUAL ADDITIONS START -->

Design Note:
All new mechanics MUST reinforce world-switching. If a feature does not interact with the Shadow/Real duality — it is not allowed.

Pending:

Post-processing profiles for Real/Shadow worlds

Light-based Shadow visibility system (optional enhancement)

<!-- MANUAL ADDITIONS END -->