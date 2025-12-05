using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class RemoveMissingScripts
{
    [MenuItem("Tools/Remove Missing Scripts In Scene")]
    public static void RemoveMissingInScene()
    {
        int removedCount = 0;
        var scene = SceneManager.GetActiveScene();
        var roots = scene.GetRootGameObjects();

        foreach (var root in roots)
        {
            removedCount += RemoveMissingFromGameObject(root);
        }

        Debug.Log($"[RemoveMissingScripts] Removed missing components: {removedCount}");
        EditorUtility.DisplayDialog("Remove Missing Scripts", $"Removed missing components: {removedCount}", "OK");
    }

    static int RemoveMissingFromGameObject(GameObject go)
    {
        int removed = 0;

        // Use SerializedObject to modify the GameObject's component array
        var so = new SerializedObject(go);
        var prop = so.FindProperty("m_Component");
        if (prop != null && prop.isArray)
        {
            // Iterate backwards when removing
            for (int i = prop.arraySize - 1; i >= 0; i--)
            {
                var element = prop.GetArrayElementAtIndex(i);
                var compProp = element.FindPropertyRelative("component");
                if (compProp != null && compProp.objectReferenceValue == null)
                {
                    Undo.RegisterCompleteObjectUndo(go, "Remove Missing Script");
                    prop.DeleteArrayElementAtIndex(i);
                    removed++;
                }
            }

            if (removed > 0)
            {
                so.ApplyModifiedProperties();
                EditorUtility.SetDirty(go);
            }
        }

        // Recurse children
        for (int c = 0; c < go.transform.childCount; c++)
        {
            var child = go.transform.GetChild(c).gameObject;
            removed += RemoveMissingFromGameObject(child);
        }

        return removed;
    }
}
