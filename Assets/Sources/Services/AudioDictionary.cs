using System.Collections.Generic;
using cln.Sources.Services;
using UnityEngine;

//[CreateAssetMenu(fileName = "AudioDictionary", menuName = "Mogze/AudioDictionary", order = 1)] This also creates the asset
public class AudioDictionary : ScriptableObject
{
    public Clip[] Names;
    public AudioClip[] AudioClips;

    public Dictionary<Clip, AudioClip> GetAudioClips()
    {
        var dictionary = new Dictionary<Clip, AudioClip>();
        for (int i = 0; i < Names.Length; i++)
        {
            dictionary.Add(Names[i], AudioClips[i]);
        }

        return dictionary;
    }
}