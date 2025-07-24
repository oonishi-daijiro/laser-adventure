using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    public enum SoundEffectKind
    {
        LaserCollision,
        Cash
    };

    static private Dictionary<SoundEffectKind, AudioClip> soundEffects = null;

    [SerializeField] private AudioClip cashSE;
    [SerializeField] private AudioClip laserCollisionSe;
    static private AudioSource audioSrc;

    void Awake()
    {
        soundEffects ??= new();
        audioSrc = GetComponent<AudioSource>();
    }

    void Start()
    {
        soundEffects[SoundEffectKind.Cash] = cashSE;
        soundEffects[SoundEffectKind.LaserCollision] = laserCollisionSe;
    }

    static public void PlaySoundEffect(SoundEffectKind kind)
    {
        if (soundEffects != null && soundEffects.ContainsKey(kind))
        {
            audioSrc.PlayOneShot(soundEffects[kind]);
        }
    }
}
