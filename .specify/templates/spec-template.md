# Feature Specification: [FEATURE NAME]

**Feature Branch**: `[###-feature-name]`  
# Feature Specification: World Switching Mechanic

**Feature Branch**: `001-world-switch`  
**Created**: 2025-12-04  
**Status**: Draft  
**Input**: User description: "Implement core mechanic to switch between Real and Shadow worlds for player and level objects."

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Switch Worlds (Priority: P1)

As a player, I want to press a button to switch between Real and Shadow worlds, so that I can access platforms, avoid hazards, and progress through levels.

**Why this priority**: This is the core gameplay mechanic; without it, the game is unplayable.

**Independent Test**: Can be fully tested by pressing the switch button in a prototype level and observing that all world-specific objects toggle correctly.

**Acceptance Scenarios**:

1. **Given** the player is in the Real world, **When** the switch button is pressed, **Then** all Shadow-only objects become active and Real-only objects deactivate.
2. **Given** the player is in the Shadow world, **When** the switch button is pressed, **Then** all Real-only objects become active and Shadow-only objects deactivate.

---

### User Story 2 - Interact with World-Specific Platforms (Priority: P2)

As a player, I want to land on platforms that exist only in one world, so that I can navigate levels safely.

**Why this priority**: Necessary to test level traversal and reinforce the switch mechanic.

**Independent Test**: Place the player above a Shadow-only platform in Real world, switch, and verify they can land safely.

**Acceptance Scenarios**:

1. **Given** the player is above a Shadow-only platform in the Real world, **When** the player switches, **Then** the player lands on the platform correctly.
2. **Given** the player is on a Shadow platform, **When** they switch to Real, **Then** the platform disappears and the player falls if no other support exists.

---

### User Story 3 - Avoid World-Specific Hazards (Priority: P2)

As a player, I want hazards to appear only in one world, so I can strategize when to switch.

**Why this priority**: Adds challenge and depth to gameplay.

**Independent Test**: Place a Real-only spike hazard; switching to Shadow world should make it inactive.

**Acceptance Scenarios**:

1. **Given** the player approaches a Real-only hazard, **When** they switch to Shadow, **Then** the hazard becomes inactive.
2. **Given** the player switches back to Real, **Then** the hazard reactivates.

---

### Edge Cases

- What happens if the player switches while falling?
- How does the system handle objects that exist in both worlds?
- What if a platform disappears under the player mid-air?
- Rapid repeated switching (spam test) — must be deterministic and safe.

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: System MUST toggle all objects between Real and Shadow worlds on player input.
- **FR-002**: Player MUST maintain momentum during world switch.
- **FR-003**: Platforms and hazards MUST activate/deactivate according to world assignment.
- **FR-004**: `ShadowWorldManager` MUST act as single source of truth for world state.
- **FR-005**: System MUST prevent switching if it causes player clipping or fatal errors (safety checks/event veto).

**Optional / Needs Clarification**:

- **FR-006**: Visual or audio feedback on switch [NEEDS CLARIFICATION: FX type and intensity].
- **FR-007**: Persistence rules for temporary objects between worlds [NEEDS CLARIFICATION].

### Key Entities *(include if feature involves data)*

- **Player**: Attributes include `position`, `velocity`, `currentWorld`, `isGrounded`, `jumpState`.
- **ShadowWorldManager**: Tracks global world state, exposes `SwitchWorld()` API, broadcasts events (e.g., `OnWorldChanged`).
- **WorldObject (abstract/base)**: Base class for platforms, hazards, enemies; includes `isShadowObject` / `isRealObject` flags and `OnWorldChanged` handler.

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: 100% of world-specific objects toggle correctly on switch (verified by automated PlayMode tests).
- **SC-002**: Player maintains position and momentum after switching within acceptable delta (e.g., position ±0.05 units, velocity preserved to within 95%).
- **SC-003**: No crashes or physics errors during rapid switching (tested up to 5 switches/second).
- **SC-004**: Prototype level can be completed using only the switch mechanic.

---

Notes:

- Implementations must follow the Shadow Swap Constitution: Mechanic-First Design, Deterministic Behavior, Single Toggle Source of Truth, Prototype-First.
- Use `ScriptableObject`s for public gameplay parameters and `SceneController` for scene lifecycle management.

Generated for: Shadow Swap — World Switching Mechanic
- **FR-005**: System MUST [behavior, e.g., "log all security events"]

*Example of marking unclear requirements:*

- **FR-006**: System MUST authenticate users via [NEEDS CLARIFICATION: auth method not specified - email/password, SSO, OAuth?]
- **FR-007**: System MUST retain user data for [NEEDS CLARIFICATION: retention period not specified]

### Key Entities *(include if feature involves data)*

- **[Entity 1]**: [What it represents, key attributes without implementation]
- **[Entity 2]**: [What it represents, relationships to other entities]

## Success Criteria *(mandatory)*

<!--
  ACTION REQUIRED: Define measurable success criteria.
  These must be technology-agnostic and measurable.
-->

### Measurable Outcomes

- **SC-001**: [Measurable metric, e.g., "Users can complete account creation in under 2 minutes"]
- **SC-002**: [Measurable metric, e.g., "System handles 1000 concurrent users without degradation"]
- **SC-003**: [User satisfaction metric, e.g., "90% of users successfully complete primary task on first attempt"]
- **SC-004**: [Business metric, e.g., "Reduce support tickets related to [X] by 50%"]
