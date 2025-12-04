---

description: "Task list template for feature implementation"
---
# Tasks: [FEATURE NAME]

 # Tasks: World Switching Mechanic

 **Input**: Design documents from `/specs/001-world-switch/`
 **Prerequisites**: `plan.md`, `spec.md`, `research.md`, `data-model.md`, `contracts/`

 **Tests**: Optional — include Unity EditMode and PlayMode tests where noted

 **Organization**: Tasks grouped by user story for independent implementation/testing

 **Format**: `[ID] [P?] [Story] Description`

 - **[P]**: Can run in parallel (different scripts/files, no dependencies)
 - **[Story]**: Which user story this task belongs to (US1, US2, US3)

## Phase 1: Setup (Shared Infrastructure)

Purpose: Project initialization and basic structure

 - [ ] T001 Create Unity project structure under `Assets/` (`Scripts/`, `Prefabs/`, `ScriptableObjects/`)
 - [ ] T002 Initialize project with Unity 2022+, URP 2D, Input System, Cinemachine
 - [ ] T003 [P] Configure MCP + Copilot integration for automated code assistance

---

## Phase 2: Foundational (Blocking Prerequisites)

Purpose: Core systems that MUST exist before any user story

 - [ ] T004 Create `ShadowWorldManager.cs` under `Assets/Scripts/Core/`
 - [ ] T005 [P] Define `WorldObject` base class (platforms, hazards, enemies) under `Assets/Scripts/World/Common/`
 - [ ] T006 [P] Implement global world-switch event system (events, delegates, centralized dispatcher)
 - [ ] T007 Configure `ScriptableObject` templates for world-specific data (`[Feature]Config.asset`)
 - [ ] T008 Setup EditMode & PlayMode testing framework under `Assets/Tests/`
 - [ ] T009 Setup logging/debug utilities for world-switch events (console + optional in-game overlay)

**Checkpoint**: Foundation ready — User Story implementation can now proceed in parallel

---

## Phase 3: User Story 1 - Switch Worlds (Priority: P1) 🎯 MVP

Goal: Player can switch between Real and Shadow worlds, activating/deactivating objects

Independent Test: Verify switch button toggles all world-specific objects correctly

### Implementation

 - [ ] T010 [P] Implement `SwitchWorld()` method in `ShadowWorldManager.cs` (state toggle + event broadcast)
 - [ ] T011 [P] Attach switch input to `PlayerController.cs` (map input action and call `SwitchWorld()`)
 - [ ] T012 [US1] Update `WorldObject` components to respond to switch events (enable/disable visuals & colliders)
 - [ ] T013 [US1] Ensure physics and collisions update correctly after switch (Rigidbody/Collider adjustments)
 - [ ] T014 [US1] Add basic visual feedback (color shift / fade / simple FX) on switch
 - [ ] T015 [US1] Add EditMode unit tests for `ShadowWorldManager` toggling logic

---

## Phase 4: User Story 2 - Interact with World-Specific Platforms (Priority: P2)

Goal: Player can land on platforms/hazards that exist only in one world

Independent Test: Place player above a Shadow platform in Real world, switch, and confirm correct landing

### Implementation

 - [ ] T016 [US2] Implement `WorldObject` activation/deactivation rules for platform behaviour (support states)
 - [ ] T017 [US2] Adjust Rigidbody/Collider updates for switching (kinematic toggles, collider enable/disable)
 - [ ] T018 [US2] Add PlayMode tests for landing/falling behavior across switches
 - [ ] T019 [US2] Integrate visual feedback with switch mechanic (platform-specific cues)

---

## Phase 5: User Story 3 - Avoid World-Specific Hazards (Priority: P3)

Goal: Hazards exist only in their assigned world and toggle safely

Independent Test: Place Real-only hazard, switch to Shadow → inactive; switch back → active

### Implementation

 - [ ] T020 [US3] Implement hazard activation/deactivation logic (damage toggles, active flags)
 - [ ] T021 [US3] Update collision detection for world-specific hazards (layer masks)
 - [ ] T022 [US3] Add tests for hazard toggling (EditMode/PlayMode as appropriate)
 - [ ] T023 [US3] Integrate hazard behavior with player movement and switches (safety checks)

---

## Phase N: Polish & Cross-Cutting Concerns

 - [ ] T030 [P] Add final visual/audio feedback polish for switching (VFX/SFX tuning)
 - [ ] T031 Refactor code for clarity and maintainability (reduce duplication)
 - [ ] T032 Optimize performance: ensure `<1ms` per switch (profiling + micro-optimizations)
 - [ ] T033 Update `docs/quickstart.md` with switch mechanic instructions and test steps
 - [ ] T034 Add additional unit and integration tests (if requested)

---

## Dependencies & Execution Order

 - **Setup (Phase 1)**: No dependencies, can start immediately
 - **Foundational (Phase 2)**: Blocks all user stories until complete
 - **User Stories (Phase 3+)**: Depend on Foundational; can proceed in parallel afterwards
 - **Polish (Final Phase)**: Depends on all user stories completion

### Notes

 - `[P]` tasks = parallelizable
 - Each user story is independently testable and should be validated at checkpoints
 - Verify tests fail before implementing where tests are included
 - Commit per task or logical group
 - Stop at checkpoints to validate story independently

Generated for: Shadow Swap — World Switching Mechanic
