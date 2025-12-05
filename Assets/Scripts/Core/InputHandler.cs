using UnityEngine;

/// <summary>
/// Simple input handler that calls ShadowWorldManager.SwitchWorld() when Tab is pressed.
/// Attach to a persistent game object (e.g., an 'Input' GameObject or the SceneController).
/// Uses InputCompat so it works with the new Input System.
/// </summary>
public class InputHandler : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Tab;

    void Update()
    {
        if (InputCompat.GetKeyDown(toggleKey))
        {
            if (ShadowWorldManager.Instance != null)
                ShadowWorldManager.Instance.SwitchWorld();
        }
    }
}
