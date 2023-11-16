using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManagerScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bgMusic;
    public AudioClip nevSpawn;
    public AudioClip nevRespawn;
    public AudioClip nevAlert;
    public AudioClip nevPortrait;
    public AudioClip nevVoid;
    public AudioClip nevDisarray;

    public static SfxManagerScript sfxInstance;

    private void Awake()
    {
        if(sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
