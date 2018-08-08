using UnityEngine;

public class MaterialDictionary : ScriptableObject
{
    public Material[] Materials;

    public Material GetRandomMaterial()
    {
        return Materials[Random.Range(0, Materials.Length)];
    }
}