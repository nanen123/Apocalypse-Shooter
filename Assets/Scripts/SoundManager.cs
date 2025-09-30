using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct mySoundClip
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    [SerializeField] public static SoundManager instance;
    public List<mySoundClip> soundlist;
    public Dictionary<string, AudioClip> sounddict;
    private AudioSource audioSource;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        DontDestroyOnLoad(instance);

        audioSource = GetComponent<AudioSource>();

        Init();
    }

    private void Init()
    {
        sounddict = new Dictionary<string, AudioClip>();
        foreach (var s in soundlist)
        {
            sounddict.Add(s.name, s.clip);
        }

    }

    public void Play(string name)
    {
        audioSource.clip = sounddict[name];
        audioSource.Play();
    }
}
