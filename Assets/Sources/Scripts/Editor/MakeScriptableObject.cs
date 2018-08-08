using UnityEngine;
using UnityEditor;

public class MakeScriptableObject
{
    [MenuItem("Mogze/Create/AudioDictionary")]
    public static void CreateAudioDictionary()
    {
        AudioDictionary asset = ScriptableObject.CreateInstance<AudioDictionary>();

        AssetDatabase.CreateAsset(asset, "Assets/Resources/AudioDictionary.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    [MenuItem("Mogze/Create/MaterialDictionary")]
    public static void CreateMaterialDictionary()
    {
        MaterialDictionary asset = ScriptableObject.CreateInstance<MaterialDictionary>();
        
        AssetDatabase.CreateAsset(asset, "Assets/Resources/Materials.asset");
        AssetDatabase.SaveAssets();
        
        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}