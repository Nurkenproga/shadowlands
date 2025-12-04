# Shadow Swap Constitution

## Core Principles

I. Mechanic-First Design

The core mechanic — switching between Real and Shadow worlds — is the foundation of all design and implementation decisions.
Every feature must reinforce, extend, or meaningfully interact with the dual-world mechanic.
Before adding anything, the team verifies:

“Does this make the world-switching mechanic stronger or clearer?”

II. Minimalism & Clarity

The game world is intentionally minimalistic.
Each object must have one clear purpose (platform, hazard, enemy, trigger, interactive element).
Unnecessary visuals, complexity, or ambiguous objects are prohibited.
Readability of gameplay always comes before aesthetics.

III. Prototype-First (NON-NEGOTIABLE)

All gameplay features begin as simple prototypes with primitive shapes.
Only after validating fun and usability can visuals, effects, and polish be added.
Lifecycle:
Prototype → Validate → Implement → Polish

IV. Deterministic Behavior

All systems must behave identically under identical conditions.
This includes:

- consistent speeds
- consistent world-switch timing
- consistent physics

Randomness is only allowed if controlled and predictable.
The game should never mislead the player.

V. Single Toggle Source of Truth

World-switching is a global state managed by one controller: `ShadowWorldManager`.
All Real/Shadow objects must subscribe to the same world-switch signal.
Multiple independent toggles are disallowed to prevent inconsistency and desync.

## Additional Constraints

Performance & Architecture

The game is strictly 2D.

Tilemaps are the primary method of level construction.

Real and Shadow objects must occupy separate layers.

Switching worlds must execute within <1ms using simple enable/disable operations.

Level Design Rules

Every level must:

- Introduce a new variation or idea tied to world-switching.
- Test the player’s mastery through combinations of mechanics.
- Avoid clutter and confusion.
- Present one clear objective (reach the exit).
- Include no more than 3 hazard types per level.

Stability & Safety

No direct scene calls; always use a centralized `SceneController`.

Public gameplay parameters should be stored in `ScriptableObject`s.

Build versions must be stable, reproducible, and testable.

## Development Workflow

1. Feature Flow

Create a task in the format:
“Add new Shadow-only platform type”

Implement a small prototype with primitive shapes.

Confirm correct behavior in both worlds.

Test mechanical integrity.

Add polish, effects, and audio.

Integrate the feature into the game’s levels.

2. Code Review Requirements

Every PR must be checked for:

- compliance with the dual-world mechanic
- architectural simplicity
- code readability without excessive comments
- no duplicated logic between Real and Shadow modes
- updated documentation

Any PR breaking Mechanic-First Design is rejected.

3. Quality Gates

A feature is “complete” only if:

- it works consistently in both worlds
- no visual glitches appear during switching
- prototype levels are fully playable
- performance remains stable
- layers and collisions are correctly configured

## Governance

This Constitution overrides all other design or architectural preferences.

Any revisions must include a written explanation answering:
“How does this strengthen the world-switch mechanic?”

All PRs must verify compliance with the Constitution.

Major changes require a documented proposal and review.

**Version**: 1.0.0 | **Ratified**: 2025-12-04 | **Last Amended**: 2025-12-04
