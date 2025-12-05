using UnityEngine;

[CreateAssetMenu(fileName = "WorldSettings", menuName = "Shadowlands/World Settings", order = 1)]
public class WorldSettings : ScriptableObject
{
    [Header("Player")]
    public float playerMoveSpeed = 5f;
    public float playerJumpForce = 5f;

    [Header("World Switch")]
    [Tooltip("Cooldown (seconds) between world switches")]
    public float switchCooldown = 0.2f;

    [Header("Physics")]
    public float gravityScale = 1f;

    [Header("Debug")]
    public bool logWorldSwitches = false;
}
