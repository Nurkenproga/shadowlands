using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

/// <summary>
/// Small compatibility wrapper so scripts written for the legacy Input API can work
/// when the new Input System package is active. Only maps common keys used by the demo.
/// Extend as needed.
/// </summary>
public static class InputCompat
{
    public static bool GetKey(KeyCode key)
    {
#if ENABLE_INPUT_SYSTEM
        var kb = Keyboard.current;
        if (kb == null) return false;
        switch (key)
        {
            case KeyCode.W: return kb.wKey.isPressed;
            case KeyCode.A: return kb.aKey.isPressed;
            case KeyCode.S: return kb.sKey.isPressed;
            case KeyCode.D: return kb.dKey.isPressed;
            case KeyCode.LeftShift: return kb.leftShiftKey.isPressed;
            case KeyCode.RightShift: return kb.rightShiftKey.isPressed;
            case KeyCode.Space: return kb.spaceKey.isPressed;
            case KeyCode.Tab: return kb.tabKey.isPressed;
            default: return false;
        }
#else
        return UnityEngine.Input.GetKey(key);
#endif
    }

    public static bool GetKeyDown(KeyCode key)
    {
#if ENABLE_INPUT_SYSTEM
        var kb = Keyboard.current;
        if (kb == null) return false;
        switch (key)
        {
            case KeyCode.W: return kb.wKey.wasPressedThisFrame;
            case KeyCode.A: return kb.aKey.wasPressedThisFrame;
            case KeyCode.S: return kb.sKey.wasPressedThisFrame;
            case KeyCode.D: return kb.dKey.wasPressedThisFrame;
            case KeyCode.LeftShift: return kb.leftShiftKey.wasPressedThisFrame;
            case KeyCode.RightShift: return kb.rightShiftKey.wasPressedThisFrame;
            case KeyCode.Space: return kb.spaceKey.wasPressedThisFrame;
            case KeyCode.Tab: return kb.tabKey.wasPressedThisFrame;
            default: return false;
        }
#else
        return UnityEngine.Input.GetKeyDown(key);
#endif
    }
}
