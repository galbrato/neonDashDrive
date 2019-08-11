using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTracksLookupTable : MonoBehaviour
{
    public static MusicTracksLookupTable instance = null;

    public string[] keys;
    public struct MusicTrack
    {
        AudioClip[] values;
        float[] loopTimes;
    }
    public AudioClip[] values;
    public float[] loopTimes;

    Dictionary<string, AudioClip> dictionary = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        LoadDictionary();
    }

    void LoadDictionary()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            dictionary.Add(keys[i], values[i]);
        }
    }

    public AudioClip FetchAudioClip(string key)
    {
        return dictionary[key];
    }
}
