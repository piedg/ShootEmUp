using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoSingleton<AudioController>
{
    AudioSource[] Sources;

    public AudioClip OnHitAudio;
    public AudioClip OnDeathAudio;
    public AudioClip OnShootAudio;

    void Awake()
    {
        Sources = GetComponents<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void PlayClip(AudioClip _clip)
    {
        for (int i = 0; i < Sources.Length; i++)
        {
            if (!Sources[i].isPlaying)
            {
                Sources[i].clip = _clip;
                Sources[i].Play();
                break;
            }
        }
    }

    public void PlayHitAudio()
    {
        PlayClip(OnHitAudio);
    }
    public void PlayShootAudio()
    {
        PlayClip(OnShootAudio);
    }
    public void PlayDeathAudio()
    {
        PlayClip(OnDeathAudio);
    }
}
