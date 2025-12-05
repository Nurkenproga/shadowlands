using System.Collections;
using UnityEngine;

public class AutoTester : MonoBehaviour
{
    IEnumerator Start()
    {
        Debug.Log("[AutoTester] Starting tests...");

        var mgr = ShadowWorldManager.Instance;
        if (mgr == null)
        {
            Debug.LogError("[AutoTester] ShadowWorldManager not found.");
            yield break;
        }

        Debug.Log($"[AutoTester] Initial world: {mgr.CurrentWorld}");

        // Toggle world
        bool switched = mgr.SwitchWorld();
        Debug.Log($"[AutoTester] SwitchWorld called, returned: {switched}");
        yield return new WaitForSecondsRealtime(0.2f);
        Debug.Log($"[AutoTester] World after switch: {mgr.CurrentWorld}");

        // Check player presence
        var player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("[AutoTester] Player object not found (tag 'Player').");
            yield break;
        }

        var rb = player.GetComponent<Rigidbody>();
        var ctrl = player.GetComponent<ShadowlandsPlayerController>();
        Debug.Log($"[AutoTester] Player found. Rigidbody: {(rb!=null)}, Controller: {(ctrl!=null)}");
        if (ctrl!=null)
        {
            Debug.Log($"[AutoTester] Controller moveSpeed: {ctrl.moveSpeed}");
        }

        Debug.Log("[AutoTester] Tests complete.");
    }
}
