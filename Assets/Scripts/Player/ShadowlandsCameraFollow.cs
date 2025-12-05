using UnityEngine;

public class ShadowlandsCameraFollow : MonoBehaviour
{
    public string playerTag = "Player";
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    public float smoothTime = 0.12f;

    Transform target;
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        var go = GameObject.FindWithTag(playerTag);
        if (go != null) target = go.transform;
    }

    void LateUpdate()
    {
        if (target == null)
        {
            var go = GameObject.FindWithTag(playerTag);
            if (go != null) target = go.transform;
            else return;
        }

        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        transform.LookAt(target);
    }
}
