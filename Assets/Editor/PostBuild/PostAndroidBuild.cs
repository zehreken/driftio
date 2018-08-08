using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class PostAndroidBuild
{
    [PostProcessBuildAttribute(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        Debug.Log("testing " + pathToBuiltProject);
    }
}