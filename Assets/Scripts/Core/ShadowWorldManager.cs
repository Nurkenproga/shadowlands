using System;
using UnityEngine;

/// <summary>
/// Single source-of-truth for the Real/Shadow world state.
/// All objects should subscribe to OnWorldChanged to update their state.
/// Deterministic: switching toggles a simple enum and invokes the event synchronously.
/// </summary>
public class ShadowWorldManager : MonoBehaviour
{
    public static ShadowWorldManager Instance { get; private set; }

    public enum WorldState { Real, Shadow }

    public WorldState CurrentWorld { get; private set; } = WorldState.Real;

    // Event invoked immediately when world changes. Subscribers should be lightweight and deterministic.
    public event Action<WorldState> OnWorldChanged;

    [Tooltip("Optional cooldown (seconds) between switches to avoid accidental rapid toggles")]
    public float switchCooldown = 0f;

    [Tooltip("Optional WorldSettings asset reference")]
    public WorldSettings settings;

    float lastSwitchTime = -999f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (settings != null)
        {
            switchCooldown = settings.switchCooldown;
        }
    }

    /// <summary>
    /// Toggle world state. Returns true if switch occurred.
    /// </summary>
    public bool SwitchWorld()
    {
        float cd = (settings != null) ? settings.switchCooldown : switchCooldown;
        if (Time.unscaledTime - lastSwitchTime < cd) return false;

        var newState = (CurrentWorld == WorldState.Real) ? WorldState.Shadow : WorldState.Real;
        SetWorld(newState);
        lastSwitchTime = Time.unscaledTime;

        if (settings != null && settings.logWorldSwitches)
        {
            Debug.Log($"[ShadowWorldManager] Switched to {newState}");
        }

        return true;
    }

    /// <summary>
    /// Set world state explicitly. Invokes OnWorldChanged synchronously.
    /// </summary>
    public void SetWorld(WorldState state)
    {
        if (CurrentWorld == state) return;
        CurrentWorld = state;
        // Invoke event synchronously to keep deterministic behavior
        OnWorldChanged?.Invoke(CurrentWorld);
    }
}
