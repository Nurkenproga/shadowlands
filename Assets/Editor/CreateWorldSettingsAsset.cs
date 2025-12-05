#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public static class CreateWorldSettingsAsset
{
    [MenuItem("Assets/Create/Shadowlands/World Settings Asset")]
    public static void CreateAsset()
    {
        var asset = ScriptableObject.CreateInstance<WorldSettings>();
        string path = "Assets/ScriptableObjects/WorldSettings.asset";
        AssetDatabase.CreateAsset(asset, path);
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}
#endif
