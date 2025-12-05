using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class FindMissingScripts
{
    [MenuItem("Tools/Find Missing Scripts In Scene")]
    public static void FindMissingInScene()
    {
        int missingCount = 0;
        var scene = SceneManager.GetActiveScene();
        var roots = scene.GetRootGameObjects();

        foreach (var root in roots)
        {
            missingCount += ScanGameObject(root);
        }

        Debug.Log($"[FindMissingScripts] Scan complete. Missing components found: {missingCount}");
        EditorUtility.DisplayDialog("Find Missing Scripts", $"Scan complete. Missing components found: {missingCount}", "OK");
    }

    static int ScanGameObject(GameObject go)
    {
        int found = 0;
        var components = go.GetComponents<Component>();
        for (int i = 0; i < components.Length; i++)
        {
            if (components[i] == null)
            {
                string path = GetGameObjectPath(go);
                Debug.LogWarning($"[FindMissingScripts] Missing script on: {path}");
                found++;
            }
        }

        // Recurse children
        for (int c = 0; c < go.transform.childCount; c++)
        {
            var child = go.transform.GetChild(c).gameObject;
            found += ScanGameObject(child);
        }

        return found;
    }

    static string GetGameObjectPath(GameObject obj)
    {
        string path = obj.name;
        Transform t = obj.transform;
        while (t.parent != null)
        {
            t = t.parent;
            path = t.name + "/" + path;
        }
        return path;
    }
}
