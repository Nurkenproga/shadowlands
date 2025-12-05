using UnityEngine;

public class ShadowlandsPlayerController : MonoBehaviour
{
    [Tooltip("Fallback move speed if no WorldSettings asset is assigned")]
    public float moveSpeed = 5f;

    public WorldSettings settings;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (settings != null)
        {
            moveSpeed = settings.playerMoveSpeed;
        }
    }

    void Update()
    {
        float x = 0f;
        float z = 0f;

        if (InputCompat.GetKey(KeyCode.W)) z += 1f;
        if (InputCompat.GetKey(KeyCode.S)) z -= 1f;
        if (InputCompat.GetKey(KeyCode.A)) x -= 1f;
        if (InputCompat.GetKey(KeyCode.D)) x += 1f;

        Vector3 input = new Vector3(x, 0f, z);
        if (input.sqrMagnitude > 1f) input.Normalize();

        Vector3 velocity = input * moveSpeed;
        Vector3 newVel = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
        rb.linearVelocity = newVel;
    }
}
