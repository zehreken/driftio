﻿using UnityEditor;
using zehreken.i_cheat.MiniPool;

[CustomEditor(typeof(PoolInfo))]
public class PoolInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.HelpBox(MiniPool.GetInfo(), MessageType.Info);
    }
}