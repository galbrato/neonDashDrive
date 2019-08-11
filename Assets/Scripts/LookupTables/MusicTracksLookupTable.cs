using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//not used for now
public class MusicTracksLookupTable : MonoBehaviour
{
    public static MusicTracksLookupTable instance = null;

    public string[] keys;
    public struct MusicTrack
    {
        public AudioClip value;
        public float loopTime;
    }
    public AudioClip[] values;
    public float[] loopTimes;

    Dictionary<string, MusicTrack> dictionary = new Dictionary<string, MusicTrack>();

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
        MusicTrack track = new MusicTrack();
        
        for (int i = 0; i < keys.Length; i++)
        {
            track.value = values[i];
            track.loopTime = loopTimes[i];
            dictionary.Add(keys[i], track);
        }
    }

    public MusicTrack FetchAudioClip(string key)
    {
        return dictionary[key];
    }
}
